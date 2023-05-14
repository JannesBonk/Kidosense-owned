using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000019 RID: 25
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PROCESS_BASIC_INFORMATION
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00005E4C File Offset: 0x0000404C
		public int Size
		{
			get
			{
				return Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION));
			}
		}

		// Token: 0x04000102 RID: 258
		public IntPtr ExitStatus;

		// Token: 0x04000103 RID: 259
		public IntPtr PebBaseAddress;

		// Token: 0x04000104 RID: 260
		public IntPtr AffinityMask;

		// Token: 0x04000105 RID: 261
		public IntPtr BasePriority;

		// Token: 0x04000106 RID: 262
		public UIntPtr UniqueProcessId;

		// Token: 0x04000107 RID: 263
		public IntPtr InheritedFromUniqueProcessId;
	}
}
