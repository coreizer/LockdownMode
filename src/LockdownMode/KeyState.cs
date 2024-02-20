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
    using System.Runtime.InteropServices;

    [ComVisible(true)]
    public struct KeyState
    {
        public bool Ctrl;
        public bool Shift;
        public bool Alt;
        public bool Delete;

        public bool IsHotKeyPressed()
        {
            return (this.Ctrl && this.Shift && this.Alt);
        }

        public void Reset()
        {
            this.Ctrl = false;
            this.Shift = false;
            this.Alt = false;
            this.Delete = false;
        }
    }
}
