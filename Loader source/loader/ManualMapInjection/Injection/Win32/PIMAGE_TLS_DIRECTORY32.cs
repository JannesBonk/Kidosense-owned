using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000035 RID: 53
	public class PIMAGE_TLS_DIRECTORY32 : ManagedPtr<IMAGE_TLS_DIRECTORY32>
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x000022DB File Offset: 0x000004DB
		public PIMAGE_TLS_DIRECTORY32(IntPtr address) : base(address)
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000022E6 File Offset: 0x000004E6
		public PIMAGE_TLS_DIRECTORY32(object value) : base(value, true)
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000064AC File Offset: 0x000046AC
		public static PIMAGE_TLS_DIRECTORY32 operator +(PIMAGE_TLS_DIRECTORY32 c1, int c2)
		{
			return new PIMAGE_TLS_DIRECTORY32(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000064D8 File Offset: 0x000046D8
		public static PIMAGE_TLS_DIRECTORY32 operator ++(PIMAGE_TLS_DIRECTORY32 a)
		{
			return a + 1;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000064F4 File Offset: 0x000046F4
		public new static explicit operator PIMAGE_TLS_DIRECTORY32(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_TLS_DIRECTORY32 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_TLS_DIRECTORY32(ptr);
			}
			return result;
		}
	}
}
