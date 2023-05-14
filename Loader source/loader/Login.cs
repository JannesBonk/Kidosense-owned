using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using loader.Properties;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Siticone.UI.WinForms;

namespace loader
{
	// Token: 0x02000002 RID: 2
	public partial class Login : Form
	{
		// Token: 0x06000002 RID: 2
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000003 RID: 3
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000004 RID: 4 RVA: 0x00002052 File Offset: 0x00000252
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002324 File Offset: 0x00000524
		public static string get_machine_guid()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					bool flag = registryKey2 == null;
					if (flag)
					{
						throw new KeyNotFoundException(string.Format("Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					bool flag2 = value == null;
					if (flag2)
					{
						throw new IndexOutOfRangeException(string.Format("Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000023D8 File Offset: 0x000005D8
		public static void checkversion(JObject apiresult)
		{
			string b = "1";
			bool flag = apiresult["Systemversion"].ToString() != b;
			if (flag)
			{
				MessageBox.Show("Update found" + Environment.NewLine + "Version: " + apiresult["Systemversion"].ToString(), "anditv21`s panel edit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Environment.Exit(1);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002444 File Offset: 0x00000644
		public static bool checkhwid(string hwid)
		{
			bool flag = Login.get_machine_guid().ToString() == hwid || string.IsNullOrEmpty(hwid);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = Login.get_machine_guid().ToString() != hwid;
				if (flag2)
				{
					MessageBox.Show("Error: HWID doesn´t match.", "anditv21`s panel edit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000206A File Offset: 0x0000026A
		private void usernametextbox_MouseClick(object sender, MouseEventArgs e)
		{
			this.usernametextbox.Text = string.Empty;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000207E File Offset: 0x0000027E
		private void passwordtextbox_MouseClick(object sender, MouseEventArgs e)
		{
			this.passwordtextbox.Text = string.Empty;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000024A8 File Offset: 0x000006A8
		private void Login_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Login.ReleaseCapture();
				Login.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002092 File Offset: 0x00000292
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000024E4 File Offset: 0x000006E4
		private void loginbtn_Click(object sender, EventArgs e)
		{
			string text = this.usernametextbox.Text;
			byte[] bytes = Encoding.UTF8.GetBytes(this.passwordtextbox.Text);
			string text2 = Convert.ToBase64String(bytes);
			string text3 = Login.get_machine_guid();
			byte[] bytes2 = Encoding.UTF8.GetBytes(text3);
			text3 = Convert.ToBase64String(bytes2);
			string text4 = "https://kidosense.xyz/api.php";
			string text5 = "yes";
			try
			{
				HttpWebRequest httpWebRequest = WebRequest.Create(string.Concat(new string[]
				{
					text4,
					"?user=",
					text,
					"&pass=",
					text2,
					"&hwid=",
					text3,
					"&key=",
					text5
				})) as HttpWebRequest;
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "application/json";
				JObject jobject = JObject.Parse(new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream()).ReadToEnd());
				bool flag = jobject["status"].ToString() == "failed";
				if (flag)
				{
					MessageBox.Show(jobject["error"].ToString(), "anditv21`s panel edit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(1);
				}
				else
				{
					bool flag2 = jobject["banned"].ToString() == "1";
					if (flag2)
					{
						MessageBox.Show("You have been banned.", "anditv21`s panel edit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						Environment.Exit(1);
					}
					else
					{
						Login.checkversion(jobject);
						bool flag3 = !Login.checkhwid(jobject["hwid"].ToString());
						if (flag3)
						{
							Environment.Exit(1);
						}
						base.Hide();
						Main main = new Main();
						main.Closed += delegate(object s, EventArgs args)
						{
							base.Close();
						};
						main.loadcontent(jobject);
						main.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "anditv21`s panel edit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(1);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000024A8 File Offset: 0x000006A8
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Login.ReleaseCapture();
				Login.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x04000001 RID: 1
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000002 RID: 2
		public const int HT_CAPTION = 2;
	}
}
