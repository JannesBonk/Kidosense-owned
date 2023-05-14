using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000034 RID: 52
	public class PSHORT : ManagedPtr<short>
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000022C4 File Offset: 0x000004C4
		public PSHORT(IntPtr address) : base(address)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000022CF File Offset: 0x000004CF
		public PSHORT(object value) : base(value, true)
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006438 File Offset: 0x00004638
		public static PSHORT operator +(PSHORT c1, int c2)
		{
			return new PSHORT(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006464 File Offset: 0x00004664
		public static PSHORT operator ++(PSHORT a)
		{
			return a + 1;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006480 File Offset: 0x00004680
		public new static explicit operator PSHORT(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PSHORT result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PSHORT(ptr);
			}
			return result;
		}
	}
}
