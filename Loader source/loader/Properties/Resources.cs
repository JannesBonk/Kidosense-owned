using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace loader.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000020C8 File Offset: 0x000002C8
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00003F94 File Offset: 0x00002194
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("loader.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00003FDC File Offset: 0x000021DC
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000020D2 File Offset: 0x000002D2
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003FF4 File Offset: 0x000021F4
		internal static Bitmap logo
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00004024 File Offset: 0x00002224
		internal static Bitmap logo1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("logo1", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00004054 File Offset: 0x00002254
		internal static Bitmap slider
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("slider", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00004084 File Offset: 0x00002284
		internal static Bitmap x
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("x", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x0400001D RID: 29
		private static ResourceManager resourceMan;

		// Token: 0x0400001E RID: 30
		private static CultureInfo resourceCulture;
	}
}
