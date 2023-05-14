using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000036 RID: 54
	public class PIMAGE_LOAD_CONFIG_DIRECTORY32 : ManagedPtr<IMAGE_LOAD_CONFIG_DIRECTORY32>
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x000022F2 File Offset: 0x000004F2
		public PIMAGE_LOAD_CONFIG_DIRECTORY32(IntPtr address) : base(address)
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000022FD File Offset: 0x000004FD
		public PIMAGE_LOAD_CONFIG_DIRECTORY32(object value) : base(value, true)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006520 File Offset: 0x00004720
		public static PIMAGE_LOAD_CONFIG_DIRECTORY32 operator +(PIMAGE_LOAD_CONFIG_DIRECTORY32 c1, int c2)
		{
			return new PIMAGE_LOAD_CONFIG_DIRECTORY32(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000654C File Offset: 0x0000474C
		public static PIMAGE_LOAD_CONFIG_DIRECTORY32 operator ++(PIMAGE_LOAD_CONFIG_DIRECTORY32 a)
		{
			return a + 1;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006568 File Offset: 0x00004768
		public new static explicit operator PIMAGE_LOAD_CONFIG_DIRECTORY32(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_LOAD_CONFIG_DIRECTORY32 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_LOAD_CONFIG_DIRECTORY32(ptr);
			}
			return result;
		}
	}
}
