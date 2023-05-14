using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000018 RID: 24
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_IMPORT_DESCRIPTOR
	{
		// Token: 0x040000FC RID: 252
		[FieldOffset(0)]
		public uint Characteristics;

		// Token: 0x040000FD RID: 253
		[FieldOffset(0)]
		public uint OriginalFirstThunk;

		// Token: 0x040000FE RID: 254
		[FieldOffset(4)]
		public uint TimeDateStamp;

		// Token: 0x040000FF RID: 255
		[FieldOffset(8)]
		public uint ForwarderChain;

		// Token: 0x04000100 RID: 256
		[FieldOffset(12)]
		public uint Name;

		// Token: 0x04000101 RID: 257
		[FieldOffset(16)]
		public uint FirstThunk;
	}
}
