using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000032 RID: 50
	public class PBYTE : ManagedPtr<byte>
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x00002296 File Offset: 0x00000496
		public PBYTE(IntPtr address) : base(address)
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000022A1 File Offset: 0x000004A1
		public PBYTE(object value) : base(value, true)
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006350 File Offset: 0x00004550
		public static PBYTE operator +(PBYTE c1, int c2)
		{
			return new PBYTE(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000637C File Offset: 0x0000457C
		public static PBYTE operator ++(PBYTE a)
		{
			return a + 1;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006398 File Offset: 0x00004598
		public new static explicit operator PBYTE(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PBYTE result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PBYTE(ptr);
			}
			return result;
		}
	}
}
