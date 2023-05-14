using System;
using System.Runtime.InteropServices;
using System.Text;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000029 RID: 41
	public class PCHAR : ManagedPtr<char>
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000021B1 File Offset: 0x000003B1
		public PCHAR(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000021BC File Offset: 0x000003BC
		public PCHAR(object value) : base(value, true)
		{
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000021C8 File Offset: 0x000003C8
		public PCHAR(string value) : base(Encoding.UTF8.GetBytes(value), true)
		{
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005FA4 File Offset: 0x000041A4
		public static PCHAR operator +(PCHAR c1, int c2)
		{
			return new PCHAR(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005FD0 File Offset: 0x000041D0
		public static PCHAR operator ++(PCHAR a)
		{
			return a + 1;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005FEC File Offset: 0x000041EC
		public new static explicit operator PCHAR(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			PCHAR result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new PCHAR(ptr);
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006018 File Offset: 0x00004218
		public override string ToString()
		{
			return Marshal.PtrToStringAnsi(base.Address) ?? string.Empty;
		}
	}
}
