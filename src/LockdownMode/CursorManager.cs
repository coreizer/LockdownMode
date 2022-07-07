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

namespace LockdownMode
{
   using System;
   using System.Drawing;
   using System.Runtime.InteropServices;

   public sealed class CursorManager
   {
      private Point leftMost = new Point(0, 0);

      public Point Position
      {
         get {
            LPPOINT point = new LPPOINT();
            NativeMethods.GetCursorPos(point);
            return new Point(point.X, point.Y);
         }
         set {
            NativeMethods.SetCursorPos(value.X, value.Y);
         }
      }

      public Point Point { get; private set; }

      public void LeftMost()
      {
         this.Position = this.leftMost;
      }

      public Point SetCursorPosition
      {
         set {
            if (value == null) throw new ArgumentNullException(nameof(value));
            this.Point = value;
         }
      }

      public CursorManager() { }

      public CursorManager(Point point)
      {
         this.Point = point;
      }

      public void Show()
      {
         NativeMethods.SetCursorPos(this.Point.X, this.Point.Y);
         NativeMethods.ShowCursor(true);
      }

      public void Hide()
      {
         this.Point = this.Position;
         NativeMethods.ShowCursor(false);
      }
   }
}
