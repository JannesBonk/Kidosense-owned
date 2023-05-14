using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using loader.Properties;
using ManualMapInjection.Injection;
using Newtonsoft.Json.Linq;

namespace loader
{
	// Token: 0x02000003 RID: 3
	public partial class Main : Form
	{
		// Token: 0x06000011 RID: 17
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000012 RID: 18
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000013 RID: 19 RVA: 0x000020A5 File Offset: 0x000002A5
		public Main()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000031D4 File Offset: 0x000013D4
		public void loadcontent(JObject result)
		{
			string sub = result["sub"].ToString();
			int num = this.checksub(sub);
			this.subtext.Text = string.Format("You have {0} day/s left.", num);
			bool flag = num < 1;
			if (flag)
			{
				MessageBox.Show("Error: You don`t have a sub", "kidosense.xyz", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
			this.welcome.Text = string.Format("Welcome back {0} ({1})", result["username"], result["uid"]);
			this.avatar.ImageLocation = result["avatarurl"].ToString();
			bool flag2 = result["Systemstatus"].ToString() == "0";
			if (flag2)
			{
				this.statustext.Text = "Online";
				this.statustext.ForeColor = Color.Green;
			}
			else
			{
				bool flag3 = result["Systemstatus"].ToString() == "1";
				if (flag3)
				{
					this.statustext.Text = "Offline";
					this.statustext.ForeColor = Color.Red;
				}
				else
				{
					bool flag4 = result["Systemmaintenance"].ToString() == "1";
					if (flag4)
					{
						this.statustext.Text = "Maintenance";
						this.statustext.ForeColor = Color.Yellow;
					}
					else
					{
						bool flag5 = result["frozen"].ToString() == "1";
						if (flag5)
						{
							this.statustext.Text = "Subs are frozen.";
							this.statustext.ForeColor = Color.Yellow;
						}
					}
				}
			}
			this.Inviter.Text = string.Format("Inviter: {0}", result["invitedBy"]);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000033C0 File Offset: 0x000015C0
		public int checksub(string sub)
		{
			bool flag = string.IsNullOrEmpty(sub);
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int days = (DateTime.Parse(sub, CultureInfo.InvariantCulture) - DateTime.Now).Days;
				result = days;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003404 File Offset: 0x00001604
		private void Main_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002092 File Offset: 0x00000292
		private void pictureBox3_Click_1(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003404 File Offset: 0x00001604
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003440 File Offset: 0x00001640
		private void button1_Click(object sender, EventArgs e)
		{
			WebClient webClient = new WebClient();
			string text = "C:\\Windows\\Kidosens.dll";
			webClient.DownloadFile("https://kidosense.xyz/Kidosens.dll", text);
			string processName = "csgo";
			Process p = Process.GetProcessesByName(processName).FirstOrDefault<Process>();
			string path = text;
			byte[] buffer = File.ReadAllBytes(path);
			bool flag = !File.Exists(path);
			if (flag)
			{
				MessageBox.Show("Error: DLL not found");
			}
			else
			{
				ManualMapInjector manualMapInjector = new ManualMapInjector(p)
				{
					AsyncInjection = true
				};
				this.label2 = string.Format("hmodule = 0x{0:x8}", manualMapInjector.Inject(buffer).ToInt64());
				bool flag2 = File.Exists(text);
				if (flag2)
				{
					File.Delete(text);
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000020BD File Offset: 0x000002BD
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000020BD File Offset: 0x000002BD
		private void avatar_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000020C0 File Offset: 0x000002C0
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400000C RID: 12
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400000D RID: 13
		public const int HT_CAPTION = 2;

		// Token: 0x0400000E RID: 14
		private object wb;

		// Token: 0x0400000F RID: 15
		private object label2;
	}
}
