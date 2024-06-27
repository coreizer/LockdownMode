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

using LockdownMode;
using NUnit.Framework;

namespace TestProject
{
   public class CursorManagerUnitTest
   {
      private CursorManager _cursorManager;

      [SetUp]
      public void Setup() {
         this._cursorManager = new CursorManager();
      }

      [Test]
      public void PositionTest() {
         this._cursorManager.Position = new System.Drawing.Point(0, 100);

         Assert.AreEqual(this._cursorManager.Position, new System.Drawing.Point(0, 100));
      }

      [Test]
      public void SetCursorPositionTest() {
         this._cursorManager.SetCursorPosition = new System.Drawing.Point(50, 25);

         Assert.AreEqual(this._cursorManager.Point, new System.Drawing.Point(50, 25));
      }
   }
}