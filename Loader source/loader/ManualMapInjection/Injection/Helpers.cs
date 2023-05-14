using System;
using System.Text;

namespace ManualMapInjection.Injection
{
	// Token: 0x02000007 RID: 7
	internal static class Helpers
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000040CC File Offset: 0x000022CC
		internal static string ToStringAnsi(byte[] buffer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in buffer)
			{
				bool flag = b == 0;
				if (flag)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004118 File Offset: 0x00002318
		internal static bool _stricmp(char[] str1, char[] str2)
		{
			int num = Math.Min(str1.Length, str2.Length);
			for (int i = 0; i < num; i++)
			{
				bool flag = str1[i] != str2[i];
				if (flag)
				{
					return false;
				}
				bool flag2 = str1[i] == '\0';
				if (flag2)
				{
					break;
				}
			}
			return true;
		}
	}
}
