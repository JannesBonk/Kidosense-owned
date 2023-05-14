using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000014 RID: 20
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_OPTIONAL_HEADER64
	{
		// Token: 0x040000BF RID: 191
		[FieldOffset(0)]
		public MagicType Magic;

		// Token: 0x040000C0 RID: 192
		[FieldOffset(2)]
		public byte MajorLinkerVersion;

		// Token: 0x040000C1 RID: 193
		[FieldOffset(3)]
		public byte MinorLinkerVersion;

		// Token: 0x040000C2 RID: 194
		[FieldOffset(4)]
		public uint SizeOfCode;

		// Token: 0x040000C3 RID: 195
		[FieldOffset(8)]
		public uint SizeOfInitializedData;

		// Token: 0x040000C4 RID: 196
		[FieldOffset(12)]
		public uint SizeOfUninitializedData;

		// Token: 0x040000C5 RID: 197
		[FieldOffset(16)]
		public uint AddressOfEntryPoint;

		// Token: 0x040000C6 RID: 198
		[FieldOffset(20)]
		public uint BaseOfCode;

		// Token: 0x040000C7 RID: 199
		[FieldOffset(24)]
		public ulong ImageBase;

		// Token: 0x040000C8 RID: 200
		[FieldOffset(32)]
		public uint SectionAlignment;

		// Token: 0x040000C9 RID: 201
		[FieldOffset(36)]
		public uint FileAlignment;

		// Token: 0x040000CA RID: 202
		[FieldOffset(40)]
		public ushort MajorOperatingSystemVersion;

		// Token: 0x040000CB RID: 203
		[FieldOffset(42)]
		public ushort MinorOperatingSystemVersion;

		// Token: 0x040000CC RID: 204
		[FieldOffset(44)]
		public ushort MajorImageVersion;

		// Token: 0x040000CD RID: 205
		[FieldOffset(46)]
		public ushort MinorImageVersion;

		// Token: 0x040000CE RID: 206
		[FieldOffset(48)]
		public ushort MajorSubsystemVersion;

		// Token: 0x040000CF RID: 207
		[FieldOffset(50)]
		public ushort MinorSubsystemVersion;

		// Token: 0x040000D0 RID: 208
		[FieldOffset(52)]
		public uint Win32VersionValue;

		// Token: 0x040000D1 RID: 209
		[FieldOffset(56)]
		public uint SizeOfImage;

		// Token: 0x040000D2 RID: 210
		[FieldOffset(60)]
		public uint SizeOfHeaders;

		// Token: 0x040000D3 RID: 211
		[FieldOffset(64)]
		public uint CheckSum;

		// Token: 0x040000D4 RID: 212
		[FieldOffset(68)]
		public SubSystemType Subsystem;

		// Token: 0x040000D5 RID: 213
		[FieldOffset(70)]
		public DllCharacteristicsType DllCharacteristics;

		// Token: 0x040000D6 RID: 214
		[FieldOffset(72)]
		public ulong SizeOfStackReserve;

		// Token: 0x040000D7 RID: 215
		[FieldOffset(80)]
		public ulong SizeOfStackCommit;

		// Token: 0x040000D8 RID: 216
		[FieldOffset(88)]
		public ulong SizeOfHeapReserve;

		// Token: 0x040000D9 RID: 217
		[FieldOffset(96)]
		public ulong SizeOfHeapCommit;

		// Token: 0x040000DA RID: 218
		[FieldOffset(104)]
		public uint LoaderFlags;

		// Token: 0x040000DB RID: 219
		[FieldOffset(108)]
		public uint NumberOfRvaAndSizes;

		// Token: 0x040000DC RID: 220
		[FieldOffset(112)]
		public IMAGE_DATA_DIRECTORY ExportTable;

		// Token: 0x040000DD RID: 221
		[FieldOffset(120)]
		public IMAGE_DATA_DIRECTORY ImportTable;

		// Token: 0x040000DE RID: 222
		[FieldOffset(128)]
		public IMAGE_DATA_DIRECTORY ResourceTable;

		// Token: 0x040000DF RID: 223
		[FieldOffset(136)]
		public IMAGE_DATA_DIRECTORY ExceptionTable;

		// Token: 0x040000E0 RID: 224
		[FieldOffset(144)]
		public IMAGE_DATA_DIRECTORY CertificateTable;

		// Token: 0x040000E1 RID: 225
		[FieldOffset(152)]
		public IMAGE_DATA_DIRECTORY BaseRelocationTable;

		// Token: 0x040000E2 RID: 226
		[FieldOffset(160)]
		public IMAGE_DATA_DIRECTORY Debug;

		// Token: 0x040000E3 RID: 227
		[FieldOffset(168)]
		public IMAGE_DATA_DIRECTORY Architecture;

		// Token: 0x040000E4 RID: 228
		[FieldOffset(176)]
		public IMAGE_DATA_DIRECTORY GlobalPtr;

		// Token: 0x040000E5 RID: 229
		[FieldOffset(184)]
		public IMAGE_DATA_DIRECTORY TLSTable;

		// Token: 0x040000E6 RID: 230
		[FieldOffset(192)]
		public IMAGE_DATA_DIRECTORY LoadConfigTable;

		// Token: 0x040000E7 RID: 231
		[FieldOffset(200)]
		public IMAGE_DATA_DIRECTORY BoundImport;

		// Token: 0x040000E8 RID: 232
		[FieldOffset(208)]
		public IMAGE_DATA_DIRECTORY IAT;

		// Token: 0x040000E9 RID: 233
		[FieldOffset(216)]
		public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

		// Token: 0x040000EA RID: 234
		[FieldOffset(224)]
		public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

		// Token: 0x040000EB RID: 235
		[FieldOffset(232)]
		public IMAGE_DATA_DIRECTORY Reserved;
	}
}
