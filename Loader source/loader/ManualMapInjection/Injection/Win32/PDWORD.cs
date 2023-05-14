using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000030 RID: 48
	public class PDWORD : ManagedPtr<uint>
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00002268 File Offset: 0x00000468
		public PDWORD(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002273 File Offset: 0x00000473
		public PDWORD(object value) : base(value, true)
		{
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006268 File Offset: 0x00004468
		public static PDWORD operator +(PDWORD c1, int c2)
		{
			return new PDWORD(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006294 File Offset: 0x00004494
		public static PDWORD operator ++(PDWORD a)
		{
			return a + 1;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000062B0 File Offset: 0x000044B0
		public new static explicit operator PDWORD(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PDWORD result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PDWORD(ptr);
			}
			return result;
		}
	}
}
