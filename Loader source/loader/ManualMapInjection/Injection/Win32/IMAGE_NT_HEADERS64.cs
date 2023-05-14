using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000016 RID: 22
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_NT_HEADERS64
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00005DE8 File Offset: 0x00003FE8
		private string _Signature
		{
			get
			{
				return new string(this.Signature);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00005E08 File Offset: 0x00004008
		public bool isValid
		{
			get
			{
				return this._Signature == "PE\0\0";
			}
		}

		// Token: 0x040000EF RID: 239
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public char[] Signature;

		// Token: 0x040000F0 RID: 240
		[FieldOffset(4)]
		public IMAGE_FILE_HEADER FileHeader;

		// Token: 0x040000F1 RID: 241
		[FieldOffset(24)]
		public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
	}
}
