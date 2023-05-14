using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200001F RID: 31
	public struct IMAGE_TLS_DIRECTORY32
	{
		// Token: 0x0400011E RID: 286
		public uint StartAddressOfRawData;

		// Token: 0x0400011F RID: 287
		public uint EndAddressOfRawData;

		// Token: 0x04000120 RID: 288
		public uint AddressOfIndex;

		// Token: 0x04000121 RID: 289
		public uint AddressOfCallBacks;

		// Token: 0x04000122 RID: 290
		public uint SizeOfZeroFill;

		// Token: 0x04000123 RID: 291
		public uint Characteristics;
	}
}
