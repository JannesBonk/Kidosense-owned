﻿using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000E RID: 14
	public enum DllCharacteristicsType : ushort
	{
		// Token: 0x0400003D RID: 61
		RES_0 = 1,
		// Token: 0x0400003E RID: 62
		RES_1,
		// Token: 0x0400003F RID: 63
		RES_2 = 4,
		// Token: 0x04000040 RID: 64
		RES_3 = 8,
		// Token: 0x04000041 RID: 65
		IMAGE_DLL_CHARACTERISTICS_DYNAMIC_BASE = 64,
		// Token: 0x04000042 RID: 66
		IMAGE_DLL_CHARACTERISTICS_FORCE_INTEGRITY = 128,
		// Token: 0x04000043 RID: 67
		IMAGE_DLL_CHARACTERISTICS_NX_COMPAT = 256,
		// Token: 0x04000044 RID: 68
		IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 512,
		// Token: 0x04000045 RID: 69
		IMAGE_DLLCHARACTERISTICS_NO_SEH = 1024,
		// Token: 0x04000046 RID: 70
		IMAGE_DLLCHARACTERISTICS_NO_BIND = 2048,
		// Token: 0x04000047 RID: 71
		RES_4 = 4096,
		// Token: 0x04000048 RID: 72
		IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 8192,
		// Token: 0x04000049 RID: 73
		IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 32768
	}
}
