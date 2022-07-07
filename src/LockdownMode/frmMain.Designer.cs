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

namespace LockdownMode {
	partial class FrmMain {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.pictureBoxAppIcon = new System.Windows.Forms.PictureBox();
         this.buttonLockdownMode = new System.Windows.Forms.Button();
         this.timerCursor = new System.Windows.Forms.Timer(this.components);
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).BeginInit();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.pictureBoxAppIcon);
         this.groupBox1.Controls.Add(this.buttonLockdownMode);
         this.groupBox1.Location = new System.Drawing.Point(13, 28);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
         this.groupBox1.Size = new System.Drawing.Size(600, 222);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
         this.label2.Location = new System.Drawing.Point(461, 195);
         this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(131, 14);
         this.label2.TabIndex = 6;
         this.label2.Text = "© 2020-2022 coreizer";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(276, 132);
         this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(216, 15);
         this.label1.TabIndex = 4;
         this.label1.Text = "解除キー: Ctrl + Shift + Alt + Delete";
         // 
         // pictureBoxAppIcon
         // 
         this.pictureBoxAppIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.pictureBoxAppIcon.Image = global::LockdownMode.Properties.Resources.hand;
         this.pictureBoxAppIcon.Location = new System.Drawing.Point(22, 33);
         this.pictureBoxAppIcon.Margin = new System.Windows.Forms.Padding(4);
         this.pictureBoxAppIcon.Name = "pictureBoxAppIcon";
         this.pictureBoxAppIcon.Size = new System.Drawing.Size(105, 86);
         this.pictureBoxAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBoxAppIcon.TabIndex = 3;
         this.pictureBoxAppIcon.TabStop = false;
         // 
         // buttonLockdownMode
         // 
         this.buttonLockdownMode.Location = new System.Drawing.Point(224, 54);
         this.buttonLockdownMode.Margin = new System.Windows.Forms.Padding(4);
         this.buttonLockdownMode.Name = "buttonLockdownMode";
         this.buttonLockdownMode.Size = new System.Drawing.Size(306, 48);
         this.buttonLockdownMode.TabIndex = 0;
         this.buttonLockdownMode.Text = "キーボードとマウスをロックする";
         this.buttonLockdownMode.UseVisualStyleBackColor = true;
         this.buttonLockdownMode.Click += new System.EventHandler(this.buttonLockdownMode_Click);
         // 
         // timerCursor
         // 
         this.timerCursor.Interval = 1;
         this.timerCursor.Tick += new System.EventHandler(this.TimerCursor_Tick);
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
         this.menuStrip1.Size = new System.Drawing.Size(626, 24);
         this.menuStrip1.TabIndex = 5;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
         this.helpToolStripMenuItem.Text = "ヘルプ(H)";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
         this.aboutToolStripMenuItem.Text = "このアプリケーションについて";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
         // 
         // FrmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(626, 263);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.menuStrip1);
         this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.MainMenuStrip = this.menuStrip1;
         this.Margin = new System.Windows.Forms.Padding(4);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmMain";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "         ";
         this.TopMost = true;
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).EndInit();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBoxAppIcon;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonLockdownMode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timerCursor;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label label2;
	}
}

