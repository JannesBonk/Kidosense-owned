using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002B RID: 43
	public class PIMAGE_IMPORT_DESCRIPTOR : ManagedPtr<IMAGE_IMPORT_DESCRIPTOR>
	{
		// Token: 0x06000080 RID: 128 RVA: 0x000021F5 File Offset: 0x000003F5
		public PIMAGE_IMPORT_DESCRIPTOR(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002200 File Offset: 0x00000400
		public PIMAGE_IMPORT_DESCRIPTOR(object value) : base(value, true)
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000606C File Offset: 0x0000426C
		public static PIMAGE_IMPORT_DESCRIPTOR operator +(PIMAGE_IMPORT_DESCRIPTOR c1, int c2)
		{
			return new PIMAGE_IMPORT_DESCRIPTOR(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006098 File Offset: 0x00004298
		public static PIMAGE_IMPORT_DESCRIPTOR operator ++(PIMAGE_IMPORT_DESCRIPTOR a)
		{
			return a + 1;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000060B4 File Offset: 0x000042B4
		public new static explicit operator PIMAGE_IMPORT_DESCRIPTOR(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_IMPORT_DESCRIPTOR result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_IMPORT_DESCRIPTOR(ptr);
			}
			return result;
		}
	}
}
