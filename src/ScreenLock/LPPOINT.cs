﻿
namespace ScreenLock
{
   using System.Runtime.InteropServices;
   
   [StructLayout(LayoutKind.Sequential)]
   public class LPPOINT
   {
      public int X;
      public int Y;

      public LPPOINT() { }

      public LPPOINT(int x, int y)
      {
         this.X = x;
         this.Y = y;
      }
   }
}
