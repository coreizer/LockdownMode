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
   using System.Windows.Forms;

   public partial class FrmScreen : Form
   {
      public FrmScreen()
      {
         this.InitializeComponent();
      }

      private void FrmScreen_Load(object sender, EventArgs e)
      {
         this.pictureBox1.Location = new Point(
           (this.Width - this.pictureBox1.Width) / 2,
           (this.Height - this.pictureBox1.Height) / 2
         );
      }
   }
}
