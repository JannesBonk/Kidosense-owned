using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000017 RID: 23
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_SECTION_HEADER
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00005E2C File Offset: 0x0000402C
		public string Section
		{
			get
			{
				return new string(this.Name);
			}
		}

		// Token: 0x040000F2 RID: 242
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public char[] Name;

		// Token: 0x040000F3 RID: 243
		[FieldOffset(8)]
		public uint VirtualSize;

		// Token: 0x040000F4 RID: 244
		[FieldOffset(12)]
		public uint VirtualAddress;

		// Token: 0x040000F5 RID: 245
		[FieldOffset(16)]
		public uint SizeOfRawData;

		// Token: 0x040000F6 RID: 246
		[FieldOffset(20)]
		public uint PointerToRawData;

		// Token: 0x040000F7 RID: 247
		[FieldOffset(24)]
		public uint PointerToRelocations;

		// Token: 0x040000F8 RID: 248
		[FieldOffset(28)]
		public uint PointerToLinenumbers;

		// Token: 0x040000F9 RID: 249
		[FieldOffset(32)]
		public ushort NumberOfRelocations;

		// Token: 0x040000FA RID: 250
		[FieldOffset(34)]
		public ushort NumberOfLinenumbers;

		// Token: 0x040000FB RID: 251
		[FieldOffset(36)]
		public DataSectionFlags Characteristics;
	}
}
