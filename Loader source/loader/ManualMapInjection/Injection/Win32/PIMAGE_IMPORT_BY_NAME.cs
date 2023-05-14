using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000031 RID: 49
	public class PIMAGE_IMPORT_BY_NAME : ManagedPtr<IMAGE_IMPORT_BY_NAME>
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000227F File Offset: 0x0000047F
		public PIMAGE_IMPORT_BY_NAME(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000228A File Offset: 0x0000048A
		public PIMAGE_IMPORT_BY_NAME(object value) : base(value, true)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000062DC File Offset: 0x000044DC
		public static PIMAGE_IMPORT_BY_NAME operator +(PIMAGE_IMPORT_BY_NAME c1, int c2)
		{
			return new PIMAGE_IMPORT_BY_NAME(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006308 File Offset: 0x00004508
		public static PIMAGE_IMPORT_BY_NAME operator ++(PIMAGE_IMPORT_BY_NAME a)
		{
			return a + 1;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006324 File Offset: 0x00004524
		public new static explicit operator PIMAGE_IMPORT_BY_NAME(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_IMPORT_BY_NAME result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_IMPORT_BY_NAME(ptr);
			}
			return result;
		}
	}
}
