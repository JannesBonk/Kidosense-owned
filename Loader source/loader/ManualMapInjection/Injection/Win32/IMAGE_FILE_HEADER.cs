using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000011 RID: 17
	public struct IMAGE_FILE_HEADER
	{
		// Token: 0x04000088 RID: 136
		public ushort Machine;

		// Token: 0x04000089 RID: 137
		public ushort NumberOfSections;

		// Token: 0x0400008A RID: 138
		public uint TimeDateStamp;

		// Token: 0x0400008B RID: 139
		public uint PointerToSymbolTable;

		// Token: 0x0400008C RID: 140
		public uint NumberOfSymbols;

		// Token: 0x0400008D RID: 141
		public ushort SizeOfOptionalHeader;

		// Token: 0x0400008E RID: 142
		public ushort Characteristics;
	}
}
