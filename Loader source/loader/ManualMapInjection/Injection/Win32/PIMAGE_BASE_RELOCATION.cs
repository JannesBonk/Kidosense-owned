using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000033 RID: 51
	public class PIMAGE_BASE_RELOCATION : ManagedPtr<IMAGE_BASE_RELOCATION>
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x000022AD File Offset: 0x000004AD
		public PIMAGE_BASE_RELOCATION(IntPtr address) : base(address)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000022B8 File Offset: 0x000004B8
		public PIMAGE_BASE_RELOCATION(object value) : base(value, true)
		{
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000063C4 File Offset: 0x000045C4
		public static PIMAGE_BASE_RELOCATION operator +(PIMAGE_BASE_RELOCATION c1, int c2)
		{
			return new PIMAGE_BASE_RELOCATION(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000063F0 File Offset: 0x000045F0
		public static PIMAGE_BASE_RELOCATION operator ++(PIMAGE_BASE_RELOCATION a)
		{
			return a + 1;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000640C File Offset: 0x0000460C
		public new static explicit operator PIMAGE_BASE_RELOCATION(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_BASE_RELOCATION result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_BASE_RELOCATION(ptr);
			}
			return result;
		}
	}
}
