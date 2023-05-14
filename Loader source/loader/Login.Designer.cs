namespace loader
{
	// Token: 0x02000002 RID: 2
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002704 File Offset: 0x00000904
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000273C File Offset: 0x0000093C
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.Passwordlabel = new global::System.Windows.Forms.Label();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.usernametextbox = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.passwordtextbox = new global::Siticone.UI.WinForms.SiticoneTextBox();
			this.loginbtn = new global::Siticone.UI.WinForms.SiticoneButton();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.SystemColors.Control;
			this.label1.Location = new global::System.Drawing.Point(33, 54);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(73, 17);
			this.label1.TabIndex = 146;
			this.label1.Text = "Username";
			this.Passwordlabel.AutoSize = true;
			this.Passwordlabel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.857143f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Passwordlabel.ForeColor = global::System.Drawing.SystemColors.Control;
			this.Passwordlabel.Location = new global::System.Drawing.Point(33, 103);
			this.Passwordlabel.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Passwordlabel.Name = "Passwordlabel";
			this.Passwordlabel.Size = new global::System.Drawing.Size(69, 17);
			this.Passwordlabel.TabIndex = 149;
			this.Passwordlabel.Text = "Password";
			this.pictureBox3.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 16);
			this.pictureBox3.Image = global::loader.Properties.Resources.x;
			this.pictureBox3.Location = new global::System.Drawing.Point(216, 0);
			this.pictureBox3.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(56, 41);
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.pictureBox2.BackColor = global::System.Drawing.Color.FromArgb(34, 34, 34);
			this.pictureBox2.Image = global::loader.Properties.Resources.logo;
			this.pictureBox2.Location = new global::System.Drawing.Point(35, 2);
			this.pictureBox2.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(177, 35);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(32, 32, 32);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Location = new global::System.Drawing.Point(1, 1);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(269, 39);
			this.panel1.TabIndex = 152;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			this.usernametextbox.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.usernametextbox.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.usernametextbox.DefaultText = "";
			this.usernametextbox.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.usernametextbox.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.usernametextbox.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.usernametextbox.DisabledState.Parent = this.usernametextbox;
			this.usernametextbox.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.usernametextbox.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.usernametextbox.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.usernametextbox.FocusedState.Parent = this.usernametextbox;
			this.usernametextbox.ForeColor = global::System.Drawing.Color.White;
			this.usernametextbox.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.usernametextbox.HoveredState.Parent = this.usernametextbox;
			this.usernametextbox.Location = new global::System.Drawing.Point(36, 74);
			this.usernametextbox.Name = "usernametextbox";
			this.usernametextbox.PasswordChar = '\0';
			this.usernametextbox.PlaceholderText = "";
			this.usernametextbox.SelectedText = "";
			this.usernametextbox.ShadowDecoration.Parent = this.usernametextbox;
			this.usernametextbox.Size = new global::System.Drawing.Size(200, 26);
			this.usernametextbox.TabIndex = 153;
			this.passwordtextbox.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.passwordtextbox.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.passwordtextbox.DefaultText = "";
			this.passwordtextbox.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.passwordtextbox.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.passwordtextbox.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.passwordtextbox.DisabledState.Parent = this.passwordtextbox;
			this.passwordtextbox.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.passwordtextbox.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.passwordtextbox.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.passwordtextbox.FocusedState.Parent = this.passwordtextbox;
			this.passwordtextbox.ForeColor = global::System.Drawing.Color.White;
			this.passwordtextbox.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.passwordtextbox.HoveredState.Parent = this.passwordtextbox;
			this.passwordtextbox.Location = new global::System.Drawing.Point(34, 123);
			this.passwordtextbox.Name = "passwordtextbox";
			this.passwordtextbox.PasswordChar = '*';
			this.passwordtextbox.PlaceholderText = "";
			this.passwordtextbox.SelectedText = "";
			this.passwordtextbox.ShadowDecoration.Parent = this.passwordtextbox;
			this.passwordtextbox.Size = new global::System.Drawing.Size(200, 26);
			this.passwordtextbox.TabIndex = 154;
			this.loginbtn.BorderColor = global::System.Drawing.Color.FromArgb(108, 195, 18);
			this.loginbtn.BorderThickness = 1;
			this.loginbtn.CheckedState.Parent = this.loginbtn;
			this.loginbtn.CustomImages.Parent = this.loginbtn;
			this.loginbtn.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.loginbtn.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.loginbtn.ForeColor = global::System.Drawing.Color.White;
			this.loginbtn.HoveredState.Parent = this.loginbtn;
			this.loginbtn.Location = new global::System.Drawing.Point(34, 162);
			this.loginbtn.Margin = new global::System.Windows.Forms.Padding(2);
			this.loginbtn.Name = "loginbtn";
			this.loginbtn.ShadowDecoration.Parent = this.loginbtn;
			this.loginbtn.Size = new global::System.Drawing.Size(200, 32);
			this.loginbtn.TabIndex = 155;
			this.loginbtn.Text = "Login";
			this.loginbtn.Click += new global::System.EventHandler(this.loginbtn_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 16);
			base.ClientSize = new global::System.Drawing.Size(268, 218);
			base.Controls.Add(this.loginbtn);
			base.Controls.Add(this.passwordtextbox);
			base.Controls.Add(this.usernametextbox);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.Passwordlabel);
			base.Controls.Add(this.label1);
			this.ForeColor = global::System.Drawing.Color.FromArgb(0, 3, 100, 14);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000003 RID: 3
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label Passwordlabel;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000009 RID: 9
		private global::Siticone.UI.WinForms.SiticoneTextBox usernametextbox;

		// Token: 0x0400000A RID: 10
		private global::Siticone.UI.WinForms.SiticoneTextBox passwordtextbox;

		// Token: 0x0400000B RID: 11
		private global::Siticone.UI.WinForms.SiticoneButton loginbtn;
	}
}
