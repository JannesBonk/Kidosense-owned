using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000028 RID: 40
	public class PIMAGE_NT_HEADERS32 : ManagedPtr<IMAGE_NT_HEADERS32>
	{
		// Token: 0x06000073 RID: 115 RVA: 0x0000219A File Offset: 0x0000039A
		public PIMAGE_NT_HEADERS32(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000021A5 File Offset: 0x000003A5
		public PIMAGE_NT_HEADERS32(object value) : base(value, true)
		{
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005F78 File Offset: 0x00004178
		public new static explicit operator PIMAGE_NT_HEADERS32(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_NT_HEADERS32 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_NT_HEADERS32(ptr);
			}
			return result;
		}
	}
}
