using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002C RID: 44
	public class PIMAGE_SECTION_HEADER : ManagedPtr<IMAGE_SECTION_HEADER>
	{
		// Token: 0x06000085 RID: 133 RVA: 0x0000220C File Offset: 0x0000040C
		public PIMAGE_SECTION_HEADER(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002217 File Offset: 0x00000417
		public PIMAGE_SECTION_HEADER(object value) : base(value, true)
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000060E0 File Offset: 0x000042E0
		public new static explicit operator PIMAGE_SECTION_HEADER(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PIMAGE_SECTION_HEADER result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PIMAGE_SECTION_HEADER(ptr);
			}
			return result;
		}
	}
}
