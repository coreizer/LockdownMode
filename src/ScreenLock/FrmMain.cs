﻿#region License Information (GPL v3)

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

namespace LockdownMode
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
      private readonly CursorManager cursor = new CursorManager();
      private readonly List<FrmScreen> monitorCollection = new List<FrmScreen>();

      private IntPtr hookPtr;
      private NativeMethods.HookProc keyTrigger;
      private KeyState keyState = new KeyState();

      public FrmMain()
      {
         this.InitializeComponent();
         this.Text = $"{Application.ProductName} by coreizer | {Application.ProductVersion}";
      }

      private bool KeyboardHook()
      {
         try {
            if (this.hookPtr != IntPtr.Zero) {
               NativeMethods.UnhookWindowsHookEx(this.hookPtr);
               Trace.WriteLine("キーボードフックを解除しました (1)", "KeyboardHook");
            }

            this.keyTrigger = new NativeMethods.HookProc(this.HookCallback);
            Module[] modules = Assembly.GetExecutingAssembly().GetModules();
            IntPtr hmod = Marshal.GetHINSTANCE(modules.First());
            this.hookPtr = NativeMethods.SetWindowsHookEx(NativeMethods.WH_KEYBOARD_LL, this.keyTrigger, hmod, 0);
            
            if (this.hookPtr == IntPtr.Zero) {
               throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            Trace.WriteLine("キーボードフックを開始しました (1)", "KeyboardHook");
            return true;
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         return false;
      }

      private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
      {
         if (nCode < 0) {
            return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
         }

         Trace.WriteLine("キーを検知", "Callback");
         OperatingSystem osVersion = Environment.OSVersion;
         NativeMethods.KBDLLHOOKSTRUCT kbd = (NativeMethods.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeMethods.KBDLLHOOKSTRUCT));

         if ((osVersion.Version.Major == 6 && osVersion.Version.Minor >= 2) || osVersion.Version.Major > 6) {
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
                  this.UnLockDownMode();
                  return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
               }
            }
         }
         else {
            this.keyState.Alt = this.IsKeyPressed(NativeMethods.VK_LMENU);
            this.keyState.Ctrl = this.IsKeyPressed(NativeMethods.VK_LCONTROL);
            this.keyState.Shift = this.IsKeyPressed(NativeMethods.VK_LSHIFT);

            if (this.keyState.IsHotKeyPressed()) {
               if (this.IsKeyPressed(NativeMethods.VK_DELETE)) {
                  this.keyState.Delete = true;
                  this.UnLockDownMode();
                  return NativeMethods.CallNextHookEx(this.hookPtr, nCode, wParam, lParam);
               }
            }
         }

         return -1;
      }

      private void UnLockDownMode()
      {
         if (this.hookPtr != IntPtr.Zero) {
            NativeMethods.UnhookWindowsHookEx(this.hookPtr);
            Trace.WriteLine("キーボードフックを解除しました (2)", "KeyboardHook");
         }

         this.timerCursor.Stop();
         this.monitorCollection.ForEach(x => x.Close());
         this.cursor.Show();
         this.keyState.Reset();
         this.Show();
      }

      private void buttonLockdownMode_Click(object sender, EventArgs e)
      {
         try {
            if (this.KeyboardHook()) {
               this.Hide();
               this.cursor.Hide();
               this.Monitors();
               if (this.timerCursor.Enabled) {
                  this.timerCursor.Stop();
               }
               this.timerCursor.Start();
            }
            else {
               MessageBox.Show("キーボードフックに失敗しました。(win32)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public void Monitors()
      {
         this.monitorCollection.Clear();
         Screen.AllScreens.ToList().ForEach(x =>
         {
            FrmScreen formScreen = new FrmScreen() { Bounds = x.Bounds };
            formScreen.Show(this);
            this.monitorCollection.Add(formScreen);
         });
      }

      public bool IsKeyPressed(int keyCode)
      {
         return (NativeMethods.GetAsyncKeyState(keyCode) & 0x8000) > 0;
      }

      private void TimerCursor_Tick(object sender, EventArgs e)
      {
         this.cursor.LeftMost();
      }

      private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MessageBox.Show($"バージョン: {Application.ProductVersion}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      protected override void OnClosing(CancelEventArgs e)
      {
         if (this.hookPtr != IntPtr.Zero) {
            NativeMethods.UnhookWindowsHookEx(this.hookPtr);
         }

         base.OnClosing(e);
      }
   }
}
