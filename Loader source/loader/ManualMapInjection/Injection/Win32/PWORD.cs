using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002F RID: 47
	public class PWORD : ManagedPtr<ushort>
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00002251 File Offset: 0x00000451
		public PWORD(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000225C File Offset: 0x0000045C
		public PWORD(object value) : base(value, true)
		{
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000061F4 File Offset: 0x000043F4
		public static PWORD operator +(PWORD c1, int c2)
		{
			return new PWORD(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006220 File Offset: 0x00004420
		public static PWORD operator ++(PWORD a)
		{
			return a + 1;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000623C File Offset: 0x0000443C
		public new static explicit operator PWORD(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PWORD result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PWORD(ptr);
			}
			return result;
		}
	}
}
