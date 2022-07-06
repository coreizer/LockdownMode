#region License Information (GPL v3)

/**
 * Copyright (C) 2022 coreizer
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

#endregion

namespace ScreenLock
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.Linq;
   using System.Reflection;
   using System.Runtime.InteropServices;
   using System.Windows.Forms;
   using System.Diagnostics;
   
   public partial class FrmMain : Form
   {
      private IntPtr hookPtr;
      private NativeMethods.HookProc hookDelegate;
      private EventHandler unLocking;

      private CursorManager cursorManager = new CursorManager();
      private KeyState keyState = new KeyState();
      private List<FrmScreen> screenCollection = new List<FrmScreen>();

      public FrmMain()
      {
         this.InitializeComponent();
         this.unLocking += this.OnUnlocking;
      }

      private void OnUnlocking()
      {
         this.unLocking?.Invoke(this, new EventArgs());
      }

      private void OnUnlocking(object sender, EventArgs e)
      {
         if (this.hookPtr != IntPtr.Zero) {
            NativeMethods.UnhookWindowsHookEx(this.hookPtr);
            Trace.WriteLine("キーボードフックを解除しました (2)", "KeyboardHook");
         }

         this.timerCursorBlocker.Stop();
         this.screenCollection.ForEach(x => x.Close());
         this.cursorManager.Show();
         this.keyState.Reset();
         this.Show();
      }

      private bool KeyboardHook()
      {
         try {
            if (this.hookPtr != IntPtr.Zero) {
               NativeMethods.UnhookWindowsHookEx(this.hookPtr);
               Trace.WriteLine("キーボードフックを解除しました (1)", "KeyboardHook");
            }

            IntPtr hMod = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
            this.hookDelegate = new NativeMethods.HookProc(this.HookCallback);
            this.hookPtr = NativeMethods.SetWindowsHookEx(NativeMethods.WH_KEYBOARD_LL, this.hookDelegate, hMod, 0);
            if (this.hookPtr == IntPtr.Zero) {
               var errorCode = Marshal.GetLastWin32Error();
               throw new Win32Exception(errorCode);
            }

            Trace.WriteLine("キーボードフックを開始しました (1)", "KeyboardHook");
            return true;
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         return false;
      }

      protected override void OnClosing(CancelEventArgs e)
      {
         base.OnClosing(e);
         if (this.hookPtr != IntPtr.Zero) {
            NativeMethods.UnhookWindowsHookEx(this.hookPtr);
         }
      }

      private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
      {
         if (nCode < 0) {
            return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
         }

         Trace.WriteLine("キーを検知", "Callback");
         var os = Environment.OSVersion;
         var kbd = (NativeMethods.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeMethods.KBDLLHOOKSTRUCT));
         if ((os.Version.Major == 6 && os.Version.Minor >= 2) || os.Version.Major > 6) {
            if (kbd.vkCode == NativeMethods.VK_LSHIFT || kbd.vkCode == NativeMethods.VK_RSHIFT) {
               this.keyState.Shift = true;
            }
            if (kbd.vkCode == NativeMethods.VK_LCONTROL || kbd.vkCode == NativeMethods.VK_RCONTROL) {
               this.keyState.Ctrl = true;
            }
            if (kbd.vkCode == NativeMethods.VK_LMENU || kbd.vkCode == NativeMethods.VK_RMENU) {
               this.keyState.Alt = true;
            }

            if (this.keyState.IsHotKeyPressed()) {
               if (kbd.vkCode == NativeMethods.VK_DELETE) {
                  this.keyState.Delete = true;
                  this.OnUnlocking();
                  return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
               }
            }
         }
         else {
            this.keyState.Shift = this.IsKeyPressed(NativeMethods.VK_LSHIFT);
            this.keyState.Ctrl = this.IsKeyPressed(NativeMethods.VK_LCONTROL);
            this.keyState.Alt = this.IsKeyPressed(NativeMethods.VK_LMENU);

            if (this.keyState.IsHotKeyPressed()) {
               if (this.IsKeyPressed(NativeMethods.VK_DELETE)) {
                  this.keyState.Delete = true;
                  this.OnUnlocking();
                  return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
               }
            }
         }
         return 1;
      }

      private void ButtonBlocker_Click(object sender, EventArgs e)
      {
         try {
            if (this.KeyboardHook()) {
               this.Hide();
               this.cursorManager.Hide();
               this.ScreenBlocker();
               if (this.timerCursorBlocker.Enabled) {
                  this.timerCursorBlocker.Stop();
               }
               this.timerCursorBlocker.Start();
            }
            else {
               MessageBox.Show("キーボードフックに失敗しました。(win32)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public bool IsKeyPressed(int keyCode)
      {
         return (NativeMethods.GetAsyncKeyState(keyCode) & 0x8000) > 0;
      }

      public void ScreenBlocker()
      {
         this.screenCollection.Clear();
         Screen.AllScreens.ToList().ForEach(s =>
         {
            var form = new FrmScreen()
            {
               Bounds = s.Bounds
            };
            form.Show(this);
            this.screenCollection.Add(form);
         });
      }

      public void SetWindowOpacity(double opacity)
      {
         this.Opacity = opacity;
         this.screenCollection.ForEach(s => s.Opacity = opacity);
      }

      private void TimerCursorBlocker_Tick(object sender, EventArgs e)
      {
         this.cursorManager.LeftMost();
      }

      private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MessageBox.Show($"バージョン: {Application.ProductVersion}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
   }
}
