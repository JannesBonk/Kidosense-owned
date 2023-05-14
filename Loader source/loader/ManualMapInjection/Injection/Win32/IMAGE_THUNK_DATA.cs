using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200001B RID: 27
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_THUNK_DATA
	{
		// Token: 0x0400010B RID: 267
		[FieldOffset(0)]
		public uint ForwarderString;

		// Token: 0x0400010C RID: 268
		[FieldOffset(0)]
		public uint Function;

		// Token: 0x0400010D RID: 269
		[FieldOffset(0)]
		public uint Ordinal;

		// Token: 0x0400010E RID: 270
		[FieldOffset(0)]
		public uint AddressOfData;
	}
}
