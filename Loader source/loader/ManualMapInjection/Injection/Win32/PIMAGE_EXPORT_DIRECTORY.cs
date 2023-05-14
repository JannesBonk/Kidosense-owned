using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002E RID: 46
	public class PIMAGE_EXPORT_DIRECTORY : ManagedPtr<IMAGE_EXPORT_DIRECTORY>
	{
		// Token: 0x0600008D RID: 141 RVA: 0x0000223A File Offset: 0x0000043A
		public PIMAGE_EXPORT_DIRECTORY(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002245 File Offset: 0x00000445
		public PIMAGE_EXPORT_DIRECTORY(object value) : base(value, true)
		{
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006180 File Offset: 0x00004380
		public static PIMAGE_EXPORT_DIRECTORY operator +(PIMAGE_EXPORT_DIRECTORY c1, int c2)
		{
			return new PIMAGE_EXPORT_DIRECTORY(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000061AC File Offset: 0x000043AC
		public static PIMAGE_EXPORT_DIRECTORY operator ++(PIMAGE_EXPORT_DIRECTORY a)
		{
			return a + 1;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000061C8 File Offset: 0x000043C8
		public new static explicit operator PIMAGE_EXPORT_DIRECTORY(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_EXPORT_DIRECTORY result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_EXPORT_DIRECTORY(ptr);
			}
			return result;
		}
	}
}
