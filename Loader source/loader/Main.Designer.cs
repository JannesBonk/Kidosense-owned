namespace loader
{
	// Token: 0x02000003 RID: 3
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000034F4 File Offset: 0x000016F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000352C File Offset: 0x0000172C
		private void InitializeComponent()
		{
			this.welcome = new global::System.Windows.Forms.Label();
			this.statustext = new global::System.Windows.Forms.Label();
			this.subtext = new global::System.Windows.Forms.Label();
			this.Inviter = new global::System.Windows.Forms.Label();
			this.status = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.avatar = new global::System.Windows.Forms.PictureBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.avatar).BeginInit();
			base.SuspendLayout();
			this.welcome.AutoSize = true;
			this.welcome.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.welcome.ForeColor = global::System.Drawing.SystemColors.Window;
			this.welcome.Location = new global::System.Drawing.Point(100, 163);
			this.welcome.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.welcome.Name = "welcome";
			this.welcome.Size = new global::System.Drawing.Size(62, 17);
			this.welcome.TabIndex = 10;
			this.welcome.Text = "welcome";
			this.statustext.AutoSize = true;
			this.statustext.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.statustext.ForeColor = global::System.Drawing.SystemColors.Window;
			this.statustext.Location = new global::System.Drawing.Point(150, 254);
			this.statustext.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.statustext.Name = "statustext";
			this.statustext.Size = new global::System.Drawing.Size(46, 17);
			this.statustext.TabIndex = 11;
			this.statustext.Text = "status";
			this.subtext.AutoSize = true;
			this.subtext.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.subtext.ForeColor = global::System.Drawing.SystemColors.Window;
			this.subtext.Location = new global::System.Drawing.Point(100, 196);
			this.subtext.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.subtext.Name = "subtext";
			this.subtext.Size = new global::System.Drawing.Size(31, 17);
			this.subtext.TabIndex = 14;
			this.subtext.Text = "sub";
			this.Inviter.AutoSize = true;
			this.Inviter.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Inviter.ForeColor = global::System.Drawing.SystemColors.Window;
			this.Inviter.Location = new global::System.Drawing.Point(100, 227);
			this.Inviter.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Inviter.Name = "Inviter";
			this.Inviter.Size = new global::System.Drawing.Size(46, 17);
			this.Inviter.TabIndex = 15;
			this.Inviter.Text = "Inviter";
			this.status.AutoSize = true;
			this.status.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.status.ForeColor = global::System.Drawing.SystemColors.Window;
			this.status.Location = new global::System.Drawing.Point(94, 254);
			this.status.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.status.Name = "status";
			this.status.Size = new global::System.Drawing.Size(52, 17);
			this.status.TabIndex = 16;
			this.status.Text = "Status:";
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(32, 32, 32);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Location = new global::System.Drawing.Point(-7, -1);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(626, 38);
			this.panel1.TabIndex = 154;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.pictureBox3.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 16);
			this.pictureBox3.Image = global::loader.Properties.Resources.x;
			this.pictureBox3.Location = new global::System.Drawing.Point(579, 2);
			this.pictureBox3.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(47, 36);
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click_1);
			this.pictureBox2.BackColor = global::System.Drawing.Color.FromArgb(34, 34, 34);
			this.pictureBox2.Image = global::loader.Properties.Resources.logo;
			this.pictureBox2.Location = new global::System.Drawing.Point(212, -1);
			this.pictureBox2.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(188, 37);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.UseWaitCursor = true;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.button1.BackColor = global::System.Drawing.Color.Navy;
			this.button1.Location = new global::System.Drawing.Point(83, 291);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(114, 33);
			this.button1.TabIndex = 155;
			this.button1.Text = "Inject";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.avatar.Location = new global::System.Drawing.Point(68, 41);
			this.avatar.Margin = new global::System.Windows.Forms.Padding(2);
			this.avatar.Name = "avatar";
			this.avatar.Size = new global::System.Drawing.Size(94, 92);
			this.avatar.TabIndex = 9;
			this.avatar.TabStop = false;
			this.avatar.Click += new global::System.EventHandler(this.avatar_Click);
			this.textBox1.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox1.ForeColor = global::System.Drawing.SystemColors.Info;
			this.textBox1.Location = new global::System.Drawing.Point(288, 122);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new global::System.Drawing.Size(181, 193);
			this.textBox1.TabIndex = 156;
			this.textBox1.Text = "-Fixed crashes\r\n-Fixed ragebot not shooting sometimes\r\n-resolver update\r\n";
			this.textBox2.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox2.ForeColor = global::System.Drawing.SystemColors.Info;
			this.textBox2.Location = new global::System.Drawing.Point(288, 96);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new global::System.Drawing.Size(181, 20);
			this.textBox2.TabIndex = 157;
			this.textBox2.Text = "Update Log";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 16);
			base.ClientSize = new global::System.Drawing.Size(620, 349);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.status);
			base.Controls.Add(this.Inviter);
			base.Controls.Add(this.subtext);
			base.Controls.Add(this.statustext);
			base.Controls.Add(this.welcome);
			base.Controls.Add(this.avatar);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.avatar).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.PictureBox avatar;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label welcome;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label statustext;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label subtext;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label Inviter;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label status;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.TextBox textBox2;
	}
}
