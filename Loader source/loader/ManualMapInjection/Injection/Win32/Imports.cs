using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000022 RID: 34
	[SuppressUnmanagedCodeSecurity]
	internal static class Imports
	{
		// Token: 0x06000057 RID: 87
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, UIntPtr lpAddress, IntPtr dwSize, Imports.AllocationType flAllocationType, Imports.MemoryProtection flProtect);

		// Token: 0x06000058 RID: 88
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize, Imports.AllocationType flAllocationType, Imports.MemoryProtection flProtect);

		// Token: 0x06000059 RID: 89
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenProcess(Imports.ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

		// Token: 0x0600005A RID: 90
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x0600005B RID: 91
		[DllImport("Dbghelp.dll")]
		public static extern IntPtr ImageRvaToVa(IntPtr NtHeaders, IntPtr Base, UIntPtr Rva, [Optional] IntPtr LastRvaSection);

		// Token: 0x0600005C RID: 92
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcessHeap();

		// Token: 0x0600005D RID: 93
		[DllImport("kernel32.dll")]
		public static extern IntPtr HeapAlloc(IntPtr hHeap, uint dwFlags, UIntPtr dwBytes);

		// Token: 0x0600005E RID: 94
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool HeapFree(IntPtr hHeap, uint dwFlags, IntPtr lpMem);

		// Token: 0x0600005F RID: 95
		[DllImport("NTDLL.DLL", SetLastError = true)]
		public static extern int NtQueryInformationProcess(IntPtr hProcess, int pic, IntPtr pbi, uint cb, out uint pSize);

		// Token: 0x06000060 RID: 96
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out UIntPtr lpNumberOfBytesRead);

		// Token: 0x06000061 RID: 97
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x06000062 RID: 98
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, IntPtr nSize, out UIntPtr lpNumberOfBytesWritten);

		// Token: 0x06000063 RID: 99
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x06000064 RID: 100
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000065 RID: 101
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x06000066 RID: 102
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x06000067 RID: 103
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, Imports.FreeType dwFreeType);

		// Token: 0x06000068 RID: 104
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualFree(IntPtr lpAddress, int dwSize, Imports.FreeType dwFreeType);

		// Token: 0x06000069 RID: 105
		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x0600006A RID: 106
		[DllImport("kernel32.dll")]
		public static extern void GetSystemTimeAsFileTime(out FILETIME lpSystemTimeAsFileTime);

		// Token: 0x0600006B RID: 107
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		// Token: 0x0600006C RID: 108 RVA: 0x00005E70 File Offset: 0x00004070
		public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, out UIntPtr lpNumberOfBytesRead)
		{
			GCHandle gchandle = GCHandle.Alloc(lpBuffer, GCHandleType.Pinned);
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, gchandle.AddrOfPinnedObject(), lpBuffer.Length, out lpNumberOfBytesRead);
			gchandle.Free();
			return result;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005EA8 File Offset: 0x000040A8
		public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out uint lpBuffer, out UIntPtr lpNumberOfBytesRead)
		{
			byte[] array = new byte[4];
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, array, out lpNumberOfBytesRead);
			lpBuffer = BitConverter.ToUInt32(array, 0);
			return result;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005ED8 File Offset: 0x000040D8
		public static bool ReadProcessMemory<T>(IntPtr hProcess, IntPtr lpBaseAddress, out T lpBuffer, out UIntPtr lpNumberOfBytesRead) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(typeof(T))];
			bool result = Imports.ReadProcessMemory(hProcess, lpBaseAddress, array, out lpNumberOfBytesRead);
			GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			lpBuffer = Marshal.PtrToStructure<T>(gchandle.AddrOfPinnedObject());
			gchandle.Free();
			return result;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005F2C File Offset: 0x0000412C
		public static IntPtr OpenProcess(Process proc, Imports.ProcessAccessFlags flags)
		{
			return Imports.OpenProcess(flags, false, proc.Id);
		}

		// Token: 0x02000023 RID: 35
		[Flags]
		public enum AllocationType
		{
			// Token: 0x04000140 RID: 320
			Commit = 4096,
			// Token: 0x04000141 RID: 321
			Reserve = 8192,
			// Token: 0x04000142 RID: 322
			Decommit = 16384,
			// Token: 0x04000143 RID: 323
			Release = 32768,
			// Token: 0x04000144 RID: 324
			Reset = 524288,
			// Token: 0x04000145 RID: 325
			Physical = 4194304,
			// Token: 0x04000146 RID: 326
			TopDown = 1048576,
			// Token: 0x04000147 RID: 327
			WriteWatch = 2097152,
			// Token: 0x04000148 RID: 328
			LargePages = 536870912
		}

		// Token: 0x02000024 RID: 36
		[Flags]
		public enum MemoryProtection
		{
			// Token: 0x0400014A RID: 330
			Execute = 16,
			// Token: 0x0400014B RID: 331
			ExecuteRead = 32,
			// Token: 0x0400014C RID: 332
			ExecuteReadWrite = 64,
			// Token: 0x0400014D RID: 333
			ExecuteWriteCopy = 128,
			// Token: 0x0400014E RID: 334
			NoAccess = 1,
			// Token: 0x0400014F RID: 335
			ReadOnly = 2,
			// Token: 0x04000150 RID: 336
			ReadWrite = 4,
			// Token: 0x04000151 RID: 337
			WriteCopy = 8,
			// Token: 0x04000152 RID: 338
			GuardModifierflag = 256,
			// Token: 0x04000153 RID: 339
			NoCacheModifierflag = 512,
			// Token: 0x04000154 RID: 340
			WriteCombineModifierflag = 1024
		}

		// Token: 0x02000025 RID: 37
		[Flags]
		public enum ProcessAccessFlags : uint
		{
			// Token: 0x04000156 RID: 342
			All = 2035711U,
			// Token: 0x04000157 RID: 343
			Terminate = 1U,
			// Token: 0x04000158 RID: 344
			CreateThread = 2U,
			// Token: 0x04000159 RID: 345
			VirtualMemoryOperation = 8U,
			// Token: 0x0400015A RID: 346
			VirtualMemoryRead = 16U,
			// Token: 0x0400015B RID: 347
			VirtualMemoryWrite = 32U,
			// Token: 0x0400015C RID: 348
			DuplicateHandle = 64U,
			// Token: 0x0400015D RID: 349
			CreateProcess = 128U,
			// Token: 0x0400015E RID: 350
			SetQuota = 256U,
			// Token: 0x0400015F RID: 351
			SetInformation = 512U,
			// Token: 0x04000160 RID: 352
			QueryInformation = 1024U,
			// Token: 0x04000161 RID: 353
			QueryLimitedInformation = 4096U,
			// Token: 0x04000162 RID: 354
			Synchronize = 1048576U
		}

		// Token: 0x02000026 RID: 38
		[Flags]
		public enum FreeType
		{
			// Token: 0x04000164 RID: 356
			Decommit = 16384,
			// Token: 0x04000165 RID: 357
			Release = 32768
		}
	}
}
