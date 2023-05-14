using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace loader.Properties
{
	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000040B4 File Offset: 0x000022B4
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400001F RID: 31
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
