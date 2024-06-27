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

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace LockdownMode
{
   public class NativeMethods
   {
      public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadId);

      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern bool UnhookWindowsHookEx(IntPtr hhook);

      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);

      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern short GetAsyncKeyState(int vKey);

      [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
      public extern static int ShowCursor(bool bShow);

      [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
      [ResourceExposure(ResourceScope.None)]
      public static extern bool SetCursorPos(int x, int y);

      [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
      [ResourceExposure(ResourceScope.None)]
      public static extern bool GetCursorPos([In, Out] LPPOINT pt);

      public const int WH_KEYBOARD_LL = 13;
      public const int WH_KEYDOWN = 0x0100;
      public const int WH_KEYUP = 0x0101;
      public const int WH_SYSKEYDOWN = 0x0104;
      public const int WH_SYSKEYUP = 0x0105;

      public const int VK_LSHIFT = 0xA0;     // 左 Shift キー
      public const int VK_RSHIFT = 0xA1;     // 右 Shift キー

      public const int VK_LCONTROL = 0xA2;   // 左 Ctrl キー
      public const int VK_RCONTROL = 0xA3;   // 右 Ctrl キー

      public const int VK_LMENU = 0xA4;      // 左 Alt キー
      public const int VK_RMENU = 0xA5;      // 右 Alt キー

      public const int VK_DELETE = 0x2E;     // DEL キー

      [StructLayout(LayoutKind.Sequential)]
      public class KBDLLHOOKSTRUCT
      {
         public uint vkCode;
         public uint scanCode;
         public LLKHF flags;
         public uint time;
         public UIntPtr dwExtraInfo;
      }

      [Flags]
      public enum LLKHF : uint
      {
         LLKHF_EXTENDED = 0x01,
         LLKHF_LOWER_IL_INJECTED = 0x00000010,
         LLKHF_INJECTED = 0x10,
         LLKHF_ALTDOWN = 0x20,
         LLKHF_UP = 0x80
      }
   }
}
