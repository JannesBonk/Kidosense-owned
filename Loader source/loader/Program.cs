using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace loader
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00003F4C File Offset: 0x0000214C
		[STAThread]
		private static void Main()
		{
			bool flag = Environment.OSVersion.Version.Major >= 6;
			if (flag)
			{
				Program.SetProcessDPIAware();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}

		// Token: 0x06000020 RID: 32
		[DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();
	}
}
