using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000010 RID: 16
	public struct IMAGE_DOS_HEADER
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00005D60 File Offset: 0x00003F60
		private string _e_magic
		{
			get
			{
				return new string(this.e_magic);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00005D80 File Offset: 0x00003F80
		public bool isValid
		{
			get
			{
				return this._e_magic == "MZ";
			}
		}

		// Token: 0x04000075 RID: 117
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public char[] e_magic;

		// Token: 0x04000076 RID: 118
		public ushort e_cblp;

		// Token: 0x04000077 RID: 119
		public ushort e_cp;

		// Token: 0x04000078 RID: 120
		public ushort e_crlc;

		// Token: 0x04000079 RID: 121
		public ushort e_cparhdr;

		// Token: 0x0400007A RID: 122
		public ushort e_minalloc;

		// Token: 0x0400007B RID: 123
		public ushort e_maxalloc;

		// Token: 0x0400007C RID: 124
		public ushort e_ss;

		// Token: 0x0400007D RID: 125
		public ushort e_sp;

		// Token: 0x0400007E RID: 126
		public ushort e_csum;

		// Token: 0x0400007F RID: 127
		public ushort e_ip;

		// Token: 0x04000080 RID: 128
		public ushort e_cs;

		// Token: 0x04000081 RID: 129
		public ushort e_lfarlc;

		// Token: 0x04000082 RID: 130
		public ushort e_ovno;

		// Token: 0x04000083 RID: 131
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ushort[] e_res1;

		// Token: 0x04000084 RID: 132
		public ushort e_oemid;

		// Token: 0x04000085 RID: 133
		public ushort e_oeminfo;

		// Token: 0x04000086 RID: 134
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public ushort[] e_res2;

		// Token: 0x04000087 RID: 135
		public int e_lfanew;
	}
}
