using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002D RID: 45
	public class PIMAGE_THUNK_DATA : ManagedPtr<IMAGE_THUNK_DATA>
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00002223 File Offset: 0x00000423
		public PIMAGE_THUNK_DATA(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000222E File Offset: 0x0000042E
		public PIMAGE_THUNK_DATA(object value) : base(value, true)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000610C File Offset: 0x0000430C
		public static PIMAGE_THUNK_DATA operator +(PIMAGE_THUNK_DATA c1, int c2)
		{
			return new PIMAGE_THUNK_DATA(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006138 File Offset: 0x00004338
		public static PIMAGE_THUNK_DATA operator ++(PIMAGE_THUNK_DATA a)
		{
			return a + 1;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006154 File Offset: 0x00004354
		public new static explicit operator PIMAGE_THUNK_DATA(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_THUNK_DATA result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_THUNK_DATA(ptr);
			}
			return result;
		}
	}
}
