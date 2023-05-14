using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000F RID: 15
	[Flags]
	public enum DataSectionFlags : uint
	{
		// Token: 0x0400004B RID: 75
		TypeReg = 0U,
		// Token: 0x0400004C RID: 76
		TypeDsect = 1U,
		// Token: 0x0400004D RID: 77
		TypeNoLoad = 2U,
		// Token: 0x0400004E RID: 78
		TypeGroup = 4U,
		// Token: 0x0400004F RID: 79
		TypeNoPadded = 8U,
		// Token: 0x04000050 RID: 80
		TypeCopy = 16U,
		// Token: 0x04000051 RID: 81
		ContentCode = 32U,
		// Token: 0x04000052 RID: 82
		ContentInitializedData = 64U,
		// Token: 0x04000053 RID: 83
		ContentUninitializedData = 128U,
		// Token: 0x04000054 RID: 84
		LinkOther = 256U,
		// Token: 0x04000055 RID: 85
		LinkInfo = 512U,
		// Token: 0x04000056 RID: 86
		TypeOver = 1024U,
		// Token: 0x04000057 RID: 87
		LinkRemove = 2048U,
		// Token: 0x04000058 RID: 88
		LinkComDat = 4096U,
		// Token: 0x04000059 RID: 89
		NoDeferSpecExceptions = 16384U,
		// Token: 0x0400005A RID: 90
		RelativeGP = 32768U,
		// Token: 0x0400005B RID: 91
		MemPurgeable = 131072U,
		// Token: 0x0400005C RID: 92
		Memory16Bit = 131072U,
		// Token: 0x0400005D RID: 93
		MemoryLocked = 262144U,
		// Token: 0x0400005E RID: 94
		MemoryPreload = 524288U,
		// Token: 0x0400005F RID: 95
		Align1Bytes = 1048576U,
		// Token: 0x04000060 RID: 96
		Align2Bytes = 2097152U,
		// Token: 0x04000061 RID: 97
		Align4Bytes = 3145728U,
		// Token: 0x04000062 RID: 98
		Align8Bytes = 4194304U,
		// Token: 0x04000063 RID: 99
		Align16Bytes = 5242880U,
		// Token: 0x04000064 RID: 100
		Align32Bytes = 6291456U,
		// Token: 0x04000065 RID: 101
		Align64Bytes = 7340032U,
		// Token: 0x04000066 RID: 102
		Align128Bytes = 8388608U,
		// Token: 0x04000067 RID: 103
		Align256Bytes = 9437184U,
		// Token: 0x04000068 RID: 104
		Align512Bytes = 10485760U,
		// Token: 0x04000069 RID: 105
		Align1024Bytes = 11534336U,
		// Token: 0x0400006A RID: 106
		Align2048Bytes = 12582912U,
		// Token: 0x0400006B RID: 107
		Align4096Bytes = 13631488U,
		// Token: 0x0400006C RID: 108
		Align8192Bytes = 14680064U,
		// Token: 0x0400006D RID: 109
		LinkExtendedRelocationOverflow = 16777216U,
		// Token: 0x0400006E RID: 110
		MemoryDiscardable = 33554432U,
		// Token: 0x0400006F RID: 111
		MemoryNotCached = 67108864U,
		// Token: 0x04000070 RID: 112
		MemoryNotPaged = 134217728U,
		// Token: 0x04000071 RID: 113
		MemoryShared = 268435456U,
		// Token: 0x04000072 RID: 114
		MemoryExecute = 536870912U,
		// Token: 0x04000073 RID: 115
		MemoryRead = 1073741824U,
		// Token: 0x04000074 RID: 116
		MemoryWrite = 2147483648U
	}
}
