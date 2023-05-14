using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000027 RID: 39
	public class PIMAGE_DOS_HEADER : ManagedPtr<IMAGE_DOS_HEADER>
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00002183 File Offset: 0x00000383
		public PIMAGE_DOS_HEADER(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000218E File Offset: 0x0000038E
		public PIMAGE_DOS_HEADER(object value) : base(value, true)
		{
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005F4C File Offset: 0x0000414C
		public new static explicit operator PIMAGE_DOS_HEADER(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_DOS_HEADER result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_DOS_HEADER(ptr);
			}
			return result;
		}
	}
}
