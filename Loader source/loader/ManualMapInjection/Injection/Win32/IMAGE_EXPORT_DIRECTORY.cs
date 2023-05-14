using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200001C RID: 28
	public struct IMAGE_EXPORT_DIRECTORY
	{
		// Token: 0x0400010F RID: 271
		public uint Characteristics;

		// Token: 0x04000110 RID: 272
		public uint TimeDateStamp;

		// Token: 0x04000111 RID: 273
		public ushort MajorVersion;

		// Token: 0x04000112 RID: 274
		public ushort MinorVersion;

		// Token: 0x04000113 RID: 275
		public uint Name;

		// Token: 0x04000114 RID: 276
		public uint Base;

		// Token: 0x04000115 RID: 277
		public uint NumberOfFunctions;

		// Token: 0x04000116 RID: 278
		public uint NumberOfNames;

		// Token: 0x04000117 RID: 279
		public uint AddressOfFunctions;

		// Token: 0x04000118 RID: 280
		public uint AddressOfNames;

		// Token: 0x04000119 RID: 281
		public uint AddressOfNameOrdinals;
	}
}
