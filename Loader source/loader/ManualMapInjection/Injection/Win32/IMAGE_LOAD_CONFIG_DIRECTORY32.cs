using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000020 RID: 32
	public struct IMAGE_LOAD_CONFIG_DIRECTORY32
	{
		// Token: 0x04000124 RID: 292
		public uint Size;

		// Token: 0x04000125 RID: 293
		public uint TimeDateStamp;

		// Token: 0x04000126 RID: 294
		public ushort MajorVersion;

		// Token: 0x04000127 RID: 295
		public ushort MinorVersion;

		// Token: 0x04000128 RID: 296
		public uint GlobalFlagsClear;

		// Token: 0x04000129 RID: 297
		public uint GlobalFlagsSet;

		// Token: 0x0400012A RID: 298
		public uint CriticalSectionDefaultTimeout;

		// Token: 0x0400012B RID: 299
		public uint DeCommitFreeBlockThreshold;

		// Token: 0x0400012C RID: 300
		public uint DeCommitTotalFreeThreshold;

		// Token: 0x0400012D RID: 301
		public uint LockPrefixTable;

		// Token: 0x0400012E RID: 302
		public uint MaximumAllocationSize;

		// Token: 0x0400012F RID: 303
		public uint VirtualMemoryThreshold;

		// Token: 0x04000130 RID: 304
		public uint ProcessHeapFlags;

		// Token: 0x04000131 RID: 305
		public uint ProcessAffinityMask;

		// Token: 0x04000132 RID: 306
		public ushort CSDVersion;

		// Token: 0x04000133 RID: 307
		public ushort Reserved1;

		// Token: 0x04000134 RID: 308
		public uint EditList;

		// Token: 0x04000135 RID: 309
		public uint SecurityCookie;

		// Token: 0x04000136 RID: 310
		public uint SEHandlerTable;

		// Token: 0x04000137 RID: 311
		public uint SEHandlerCount;

		// Token: 0x04000138 RID: 312
		public uint GuardCFCheckFunctionPointer;

		// Token: 0x04000139 RID: 313
		public uint Reserved2;

		// Token: 0x0400013A RID: 314
		public uint GuardCFFunctionTable;

		// Token: 0x0400013B RID: 315
		public uint GuardCFFunctionCount;

		// Token: 0x0400013C RID: 316
		public uint GuardFlags;
	}
}
