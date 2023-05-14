using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002A RID: 42
	public class PPROCESS_BASIC_INFORMATION : ManagedPtr<PROCESS_BASIC_INFORMATION>
	{
		// Token: 0x0600007D RID: 125 RVA: 0x000021DE File Offset: 0x000003DE
		public PPROCESS_BASIC_INFORMATION(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000021E9 File Offset: 0x000003E9
		public PPROCESS_BASIC_INFORMATION(object value) : base(value, true)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006040 File Offset: 0x00004240
		public new static explicit operator PPROCESS_BASIC_INFORMATION(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PPROCESS_BASIC_INFORMATION result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PPROCESS_BASIC_INFORMATION(ptr);
			}
			return result;
		}
	}
}
