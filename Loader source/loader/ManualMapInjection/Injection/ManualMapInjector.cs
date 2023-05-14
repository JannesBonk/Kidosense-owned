using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ManualMapInjection.Injection.Win32;

namespace ManualMapInjection.Injection
{
	// Token: 0x02000008 RID: 8
	internal class ManualMapInjector
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000020FA File Offset: 0x000002FA
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002102 File Offset: 0x00000302
		public bool AsyncInjection { get; set; } = false;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000210B File Offset: 0x0000030B
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002113 File Offset: 0x00000313
		public uint TimeOut { get; set; } = 5000U;

		// Token: 0x06000032 RID: 50 RVA: 0x00004170 File Offset: 0x00002370
		private PIMAGE_DOS_HEADER GetDosHeader(IntPtr address)
		{
			PIMAGE_DOS_HEADER pimage_DOS_HEADER = (PIMAGE_DOS_HEADER)address;
			bool flag = !pimage_DOS_HEADER.Value.isValid;
			PIMAGE_DOS_HEADER result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = pimage_DOS_HEADER;
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000041A4 File Offset: 0x000023A4
		private PIMAGE_NT_HEADERS32 GetNtHeader(IntPtr address)
		{
			PIMAGE_DOS_HEADER dosHeader = this.GetDosHeader(address);
			bool flag = dosHeader == null;
			PIMAGE_NT_HEADERS32 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				PIMAGE_NT_HEADERS32 pimage_NT_HEADERS = (PIMAGE_NT_HEADERS32)(address + dosHeader.Value.e_lfanew);
				bool flag2 = !pimage_NT_HEADERS.Value.isValid;
				if (flag2)
				{
					result = null;
				}
				else
				{
					result = pimage_NT_HEADERS;
				}
			}
			return result;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004200 File Offset: 0x00002400
		private IntPtr RemoteAllocateMemory(uint size)
		{
			return Imports.VirtualAllocEx(this._hProcess, UIntPtr.Zero, new IntPtr((long)((ulong)size)), Imports.AllocationType.Commit | Imports.AllocationType.Reserve, Imports.MemoryProtection.ExecuteReadWrite);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004230 File Offset: 0x00002430
		private IntPtr AllocateMemory(uint size)
		{
			return Imports.VirtualAlloc(IntPtr.Zero, new UIntPtr(size), Imports.AllocationType.Commit | Imports.AllocationType.Reserve, Imports.MemoryProtection.ExecuteReadWrite);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000425C File Offset: 0x0000245C
		private IntPtr RvaToPointer(uint rva, IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				result = Imports.ImageRvaToVa(ntHeader.Address, baseAddress, new UIntPtr(rva), IntPtr.Zero);
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000042A0 File Offset: 0x000024A0
		private bool InjectDependency(string dependency)
		{
			IntPtr procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			bool flag = procAddress == IntPtr.Zero;
			bool result;
			if (flag)
			{
				Debug.WriteLine("[InjectDependency] GetProcAddress failed");
				result = false;
			}
			else
			{
				IntPtr intPtr = this.RemoteAllocateMemory((uint)dependency.Length);
				bool flag2 = intPtr == IntPtr.Zero;
				if (flag2)
				{
					Debug.WriteLine("[InjectDependency] RemoteAllocateMemory failed");
					result = false;
				}
				else
				{
					byte[] bytes = Encoding.ASCII.GetBytes(dependency);
					UIntPtr uintPtr;
					bool flag3 = Imports.WriteProcessMemory(this._hProcess, intPtr, bytes, bytes.Length, out uintPtr);
					bool flag4 = flag3;
					if (flag4)
					{
						IntPtr hHandle = Imports.CreateRemoteThread(this._hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
						bool flag5 = Imports.WaitForSingleObject(hHandle, this.TimeOut) > 0U;
						if (flag5)
						{
							Debug.WriteLine("[InjectDependency] remote thread not signaled");
							return false;
						}
					}
					else
					{
						Debug.WriteLine("[InjectDependency] WriteProcessMemory failed");
					}
					Imports.VirtualFreeEx(this._hProcess, intPtr, 0, Imports.FreeType.Release);
					result = flag3;
				}
			}
			return result;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000043B0 File Offset: 0x000025B0
		private IntPtr GetRemoteModuleHandleA(string module)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr processHeap = Imports.GetProcessHeap();
			uint num = (uint)Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION));
			PPROCESS_BASIC_INFORMATION pprocess_BASIC_INFORMATION = (PPROCESS_BASIC_INFORMATION)Imports.HeapAlloc(processHeap, 8U, new UIntPtr(num));
			uint num3;
			int num2 = Imports.NtQueryInformationProcess(this._hProcess, 0, pprocess_BASIC_INFORMATION.Address, num, out num3);
			bool flag = num2 >= 0 && num < num3;
			if (flag)
			{
				bool flag2 = pprocess_BASIC_INFORMATION != null;
				if (flag2)
				{
					Imports.HeapFree(processHeap, 0U, pprocess_BASIC_INFORMATION.Address);
				}
				pprocess_BASIC_INFORMATION = (PPROCESS_BASIC_INFORMATION)Imports.HeapAlloc(processHeap, 8U, new UIntPtr(num));
				bool flag3 = pprocess_BASIC_INFORMATION == null;
				if (flag3)
				{
					Debug.WriteLine("[GetRemoteModuleHandleA] Couldn't allocate heap buffer");
					return IntPtr.Zero;
				}
				num2 = Imports.NtQueryInformationProcess(this._hProcess, 0, pprocess_BASIC_INFORMATION.Address, num3, out num3);
			}
			bool flag4 = num2 >= 0;
			if (flag4)
			{
				bool flag5 = pprocess_BASIC_INFORMATION.Value.PebBaseAddress != IntPtr.Zero;
				if (flag5)
				{
					uint num4;
					UIntPtr uintPtr;
					bool flag6 = Imports.ReadProcessMemory(this._hProcess, pprocess_BASIC_INFORMATION.Value.PebBaseAddress + 12, out num4, out uintPtr);
					if (flag6)
					{
						uint num5 = num4 + 12U;
						uint num6 = num4 + 12U;
						uint num8;
						for (;;)
						{
							uint num7;
							bool flag7 = !Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num6)), out num7, out uintPtr);
							if (flag7)
							{
								Imports.HeapFree(processHeap, 0U, pprocess_BASIC_INFORMATION.Address);
							}
							num6 = num7;
							UNICODE_STRING unicode_STRING;
							Imports.ReadProcessMemory<UNICODE_STRING>(this._hProcess, new IntPtr((long)((ulong)num7)) + 44, out unicode_STRING, out uintPtr);
							string a = string.Empty;
							bool flag8 = unicode_STRING.Length > 0;
							if (flag8)
							{
								byte[] array = new byte[(int)unicode_STRING.Length];
								Imports.ReadProcessMemory(this._hProcess, unicode_STRING.Buffer, array, out uintPtr);
								a = Encoding.Unicode.GetString(array);
							}
							Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num7)) + 24, out num8, out uintPtr);
							uint num9;
							Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)num7)) + 32, out num9, out uintPtr);
							bool flag9 = num8 != 0U && num9 > 0U;
							if (flag9)
							{
								bool flag10 = string.Equals(a, module, StringComparison.OrdinalIgnoreCase);
								if (flag10)
								{
									break;
								}
							}
							if (num5 == num6)
							{
								goto IL_24E;
							}
						}
						zero = new IntPtr((long)((ulong)num8));
						IL_24E:;
					}
				}
			}
			bool flag11 = pprocess_BASIC_INFORMATION != null;
			if (flag11)
			{
				Imports.HeapFree(processHeap, 0U, pprocess_BASIC_INFORMATION.Address);
			}
			return zero;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004630 File Offset: 0x00002830
		private IntPtr GetDependencyProcAddressA(IntPtr moduleBase, PCHAR procName)
		{
			IntPtr intPtr = IntPtr.Zero;
			IMAGE_DOS_HEADER image_DOS_HEADER;
			UIntPtr uintPtr;
			Imports.ReadProcessMemory<IMAGE_DOS_HEADER>(this._hProcess, moduleBase, out image_DOS_HEADER, out uintPtr);
			bool flag = !image_DOS_HEADER.isValid;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IMAGE_NT_HEADERS32 image_NT_HEADERS;
				Imports.ReadProcessMemory<IMAGE_NT_HEADERS32>(this._hProcess, moduleBase + image_DOS_HEADER.e_lfanew, out image_NT_HEADERS, out uintPtr);
				bool flag2 = !image_NT_HEADERS.isValid;
				if (flag2)
				{
					result = IntPtr.Zero;
				}
				else
				{
					uint virtualAddress = image_NT_HEADERS.OptionalHeader.ExportTable.VirtualAddress;
					bool flag3 = virtualAddress > 0U;
					if (flag3)
					{
						uint size = image_NT_HEADERS.OptionalHeader.ExportTable.Size;
						PIMAGE_EXPORT_DIRECTORY pimage_EXPORT_DIRECTORY = (PIMAGE_EXPORT_DIRECTORY)this.AllocateMemory(size);
						Imports.ReadProcessMemory(this._hProcess, moduleBase + (int)virtualAddress, pimage_EXPORT_DIRECTORY.Address, (int)size, out uintPtr);
						PWORD pword = (PWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfNameOrdinals - (int)virtualAddress);
						PDWORD pdword = (PDWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfNames - (int)virtualAddress);
						PDWORD pdword2 = (PDWORD)(pimage_EXPORT_DIRECTORY.Address + (int)pimage_EXPORT_DIRECTORY.Value.AddressOfFunctions - (int)virtualAddress);
						for (uint num = 0U; num < pimage_EXPORT_DIRECTORY.Value.NumberOfFunctions; num += 1U)
						{
							PCHAR pchar = null;
							bool flag4 = new PDWORD(procName.Address).Value <= 65535U;
							ushort num2;
							if (flag4)
							{
								num2 = (ushort)num;
							}
							else
							{
								bool flag5 = new PDWORD(procName.Address).Value > 65535U && num < pimage_EXPORT_DIRECTORY.Value.NumberOfNames;
								if (!flag5)
								{
									return IntPtr.Zero;
								}
								pchar = (PCHAR)new IntPtr((long)((ulong)pdword[num] + (ulong)((long)pimage_EXPORT_DIRECTORY.Address.ToInt32()) - (ulong)virtualAddress));
								num2 = pword[num];
							}
							bool flag6 = (new PDWORD(procName.Address).Value <= 65535U && new PDWORD(procName.Address).Value == (uint)num2 + pimage_EXPORT_DIRECTORY.Value.Base) || (new PDWORD(procName.Address).Value > 65535U && pchar.ToString() == procName.ToString());
							if (flag6)
							{
								intPtr = moduleBase + (int)pdword2[(uint)num2];
								bool flag7 = intPtr.ToInt64() >= (moduleBase + (int)virtualAddress).ToInt64() && intPtr.ToInt64() <= (moduleBase + (int)virtualAddress + (int)size).ToInt64();
								if (flag7)
								{
									byte[] array = new byte[255];
									Imports.ReadProcessMemory(this._hProcess, intPtr, array, out uintPtr);
									string text = Helpers.ToStringAnsi(array);
									string text2 = text.Substring(0, text.IndexOf(".")) + ".dll";
									string text3 = text.Substring(text.IndexOf(".") + 1);
									IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(text2);
									bool flag8 = remoteModuleHandleA == IntPtr.Zero;
									if (flag8)
									{
										this.InjectDependency(text2);
									}
									bool flag9 = text3.StartsWith("#");
									if (flag9)
									{
										intPtr = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(text3) + 1);
									}
									else
									{
										intPtr = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(text3));
									}
								}
								break;
							}
						}
						Imports.VirtualFree(pimage_EXPORT_DIRECTORY.Address, 0, Imports.FreeType.Release);
					}
					result = intPtr;
				}
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000049F8 File Offset: 0x00002BF8
		private bool ProcessImportTable(IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = ntHeader.Value.OptionalHeader.ImportTable.Size > 0U;
				if (flag2)
				{
					PIMAGE_IMPORT_DESCRIPTOR pimage_IMPORT_DESCRIPTOR = (PIMAGE_IMPORT_DESCRIPTOR)this.RvaToPointer(ntHeader.Value.OptionalHeader.ImportTable.VirtualAddress, baseAddress);
					bool flag3 = pimage_IMPORT_DESCRIPTOR != null;
					if (flag3)
					{
						while (pimage_IMPORT_DESCRIPTOR.Value.Name > 0U)
						{
							PCHAR pchar = (PCHAR)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.Name, baseAddress);
							bool flag4 = pchar == null;
							if (!flag4)
							{
								bool flag5 = pchar.ToString().Contains("-ms-win-crt-");
								if (flag5)
								{
									pchar = new PCHAR("ucrtbase.dll");
								}
								IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
								bool flag6 = remoteModuleHandleA == IntPtr.Zero;
								if (flag6)
								{
									this.InjectDependency(pchar.ToString());
									remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
									bool flag7 = remoteModuleHandleA == IntPtr.Zero;
									if (flag7)
									{
										Debug.WriteLine("[ProcessImportTable] failed to obtain module handle");
										goto IL_291;
									}
								}
								bool flag8 = pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk > 0U;
								PIMAGE_THUNK_DATA pimage_THUNK_DATA;
								PIMAGE_THUNK_DATA pimage_THUNK_DATA2;
								if (flag8)
								{
									pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk, baseAddress);
									pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
								}
								else
								{
									pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
									pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
								}
								while (pimage_THUNK_DATA.Value.AddressOfData > 0U)
								{
									bool flag9 = (pimage_THUNK_DATA.Value.Ordinal & 2147483648U) > 0U;
									bool flag10 = flag9;
									IntPtr dependencyProcAddressA;
									if (flag10)
									{
										short num = (short)(pimage_THUNK_DATA.Value.Ordinal & 65535U);
										dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(num));
										bool flag11 = dependencyProcAddressA == IntPtr.Zero;
										if (flag11)
										{
											return false;
										}
									}
									else
									{
										PIMAGE_IMPORT_BY_NAME pimage_IMPORT_BY_NAME = (PIMAGE_IMPORT_BY_NAME)this.RvaToPointer(pimage_THUNK_DATA2.Value.Ordinal, baseAddress);
										PCHAR procName = (PCHAR)pimage_IMPORT_BY_NAME.Address + 2;
										dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, procName);
									}
									Marshal.WriteInt32(pimage_THUNK_DATA2.Address, dependencyProcAddressA.ToInt32());
									pimage_THUNK_DATA = ++pimage_THUNK_DATA;
									pimage_THUNK_DATA2 = ++pimage_THUNK_DATA2;
								}
							}
							IL_291:
							pimage_IMPORT_DESCRIPTOR = ++pimage_IMPORT_DESCRIPTOR;
						}
						result = true;
					}
					else
					{
						Debug.WriteLine("[ProcessImportTable] Size of table confirmed but pointer to data invalid");
						result = false;
					}
				}
				else
				{
					Debug.WriteLine("[ProcessImportTable] no imports");
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004CDC File Offset: 0x00002EDC
		private bool ProcessDelayedImportTable(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = ntHeader.Value.OptionalHeader.DelayImportDescriptor.Size > 0U;
				if (flag2)
				{
					PIMAGE_IMPORT_DESCRIPTOR pimage_IMPORT_DESCRIPTOR = (PIMAGE_IMPORT_DESCRIPTOR)this.RvaToPointer(ntHeader.Value.OptionalHeader.DelayImportDescriptor.VirtualAddress, baseAddress);
					bool flag3 = pimage_IMPORT_DESCRIPTOR != null;
					if (flag3)
					{
						while (pimage_IMPORT_DESCRIPTOR.Value.Name > 0U)
						{
							PCHAR pchar = (PCHAR)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.Name, baseAddress);
							bool flag4 = pchar == null;
							if (!flag4)
							{
								IntPtr remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
								bool flag5 = remoteModuleHandleA == IntPtr.Zero;
								if (flag5)
								{
									this.InjectDependency(pchar.ToString());
									remoteModuleHandleA = this.GetRemoteModuleHandleA(pchar.ToString());
									bool flag6 = remoteModuleHandleA == IntPtr.Zero;
									if (flag6)
									{
										Debug.WriteLine("[ProcessDelayedImportTable] no imports");
										goto IL_272;
									}
								}
								bool flag7 = pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk > 0U;
								PIMAGE_THUNK_DATA pimage_THUNK_DATA;
								PIMAGE_THUNK_DATA pimage_THUNK_DATA2;
								if (flag7)
								{
									pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.OriginalFirstThunk, baseAddress);
									pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
								}
								else
								{
									pimage_THUNK_DATA = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
									pimage_THUNK_DATA2 = (PIMAGE_THUNK_DATA)this.RvaToPointer(pimage_IMPORT_DESCRIPTOR.Value.FirstThunk, baseAddress);
								}
								while (pimage_THUNK_DATA.Value.AddressOfData > 0U)
								{
									bool flag8 = (pimage_THUNK_DATA.Value.Ordinal & 2147483648U) > 0U;
									bool flag9 = flag8;
									IntPtr dependencyProcAddressA;
									if (flag9)
									{
										short num = (short)(pimage_THUNK_DATA.Value.Ordinal & 65535U);
										dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, new PCHAR(num));
										bool flag10 = dependencyProcAddressA == IntPtr.Zero;
										if (flag10)
										{
											return false;
										}
									}
									else
									{
										PIMAGE_IMPORT_BY_NAME pimage_IMPORT_BY_NAME = (PIMAGE_IMPORT_BY_NAME)this.RvaToPointer(pimage_THUNK_DATA2.Value.Ordinal, baseAddress);
										PCHAR procName = (PCHAR)pimage_IMPORT_BY_NAME.Address + 2;
										dependencyProcAddressA = this.GetDependencyProcAddressA(remoteModuleHandleA, procName);
									}
									Marshal.WriteInt32(pimage_THUNK_DATA2.Address, dependencyProcAddressA.ToInt32());
									pimage_THUNK_DATA = ++pimage_THUNK_DATA;
									pimage_THUNK_DATA2 = ++pimage_THUNK_DATA2;
								}
							}
							IL_272:
							pimage_IMPORT_DESCRIPTOR = ++pimage_IMPORT_DESCRIPTOR;
						}
						result = true;
					}
					else
					{
						Debug.WriteLine("[ProcessDelayedImportTable] Size of table confirmed but pointer to data invalid");
						result = false;
					}
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004F98 File Offset: 0x00003198
		private bool ProcessRelocation(uint imageBaseDelta, ushort data, PBYTE relocationBase)
		{
			bool result = true;
			switch (data >> 12 & 15)
			{
			case 0:
				return result;
			case 1:
			{
				PSHORT pshort = (PSHORT)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt16(pshort.Address, (short)((long)pshort.Value + (long)((ulong)((ushort)(imageBaseDelta >> 16 & 65535U)))));
				return result;
			}
			case 2:
			{
				PSHORT pshort = (PSHORT)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt16(pshort.Address, (short)((long)pshort.Value + (long)((ulong)((ushort)(imageBaseDelta & 65535U)))));
				return result;
			}
			case 3:
			{
				PDWORD pdword = (PDWORD)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt32(pdword.Address, (int)(pdword.Value + imageBaseDelta));
				return result;
			}
			case 4:
				return result;
			case 10:
			{
				PDWORD pdword = (PDWORD)(relocationBase + (int)(data & 4095)).Address;
				Marshal.WriteInt32(pdword.Address, (int)(pdword.Value + imageBaseDelta));
				return result;
			}
			}
			result = false;
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000050CC File Offset: 0x000032CC
		private bool ProcessRelocations(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = (ntHeader.Value.FileHeader.Characteristics & 1) > 0;
				if (flag2)
				{
					result = true;
				}
				else
				{
					uint imageBaseDelta = (uint)((long)remoteAddress.ToInt32() - (long)((ulong)ntHeader.Value.OptionalHeader.ImageBase));
					uint size = ntHeader.Value.OptionalHeader.BaseRelocationTable.Size;
					bool flag3 = size > 0U;
					if (flag3)
					{
						PIMAGE_BASE_RELOCATION pimage_BASE_RELOCATION = (PIMAGE_BASE_RELOCATION)this.RvaToPointer(ntHeader.Value.OptionalHeader.BaseRelocationTable.VirtualAddress, baseAddress);
						bool flag4 = pimage_BASE_RELOCATION != null;
						if (!flag4)
						{
							return false;
						}
						PBYTE pbyte = (PBYTE)pimage_BASE_RELOCATION.Address + (int)size;
						while (pimage_BASE_RELOCATION.Address.ToInt64() < pbyte.Address.ToInt64())
						{
							PBYTE relocationBase = (PBYTE)this.RvaToPointer(pimage_BASE_RELOCATION.Value.VirtualAddress, baseAddress);
							uint num = pimage_BASE_RELOCATION.Value.SizeOfBlock - 8U >> 1;
							PWORD pword = (PWORD)(pimage_BASE_RELOCATION + 1).Address;
							uint num2 = 0U;
							while (num2 < num)
							{
								this.ProcessRelocation(imageBaseDelta, pword.Value, relocationBase);
								num2 += 1U;
								pword = ++pword;
							}
							pimage_BASE_RELOCATION = (PIMAGE_BASE_RELOCATION)pword.Address;
						}
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005264 File Offset: 0x00003464
		private uint GetSectionProtection(DataSectionFlags characteristics)
		{
			uint num = 0U;
			bool flag = characteristics.HasFlag(DataSectionFlags.MemoryNotCached);
			if (flag)
			{
				num |= 512U;
			}
			bool flag2 = characteristics.HasFlag(DataSectionFlags.MemoryExecute);
			if (flag2)
			{
				bool flag3 = characteristics.HasFlag(DataSectionFlags.MemoryRead);
				if (flag3)
				{
					bool flag4 = characteristics.HasFlag((DataSectionFlags)2147483648U);
					if (flag4)
					{
						num |= 64U;
					}
					else
					{
						num |= 32U;
					}
				}
				else
				{
					bool flag5 = characteristics.HasFlag((DataSectionFlags)2147483648U);
					if (flag5)
					{
						num |= 128U;
					}
					else
					{
						num |= 16U;
					}
				}
			}
			else
			{
				bool flag6 = characteristics.HasFlag(DataSectionFlags.MemoryRead);
				if (flag6)
				{
					bool flag7 = characteristics.HasFlag((DataSectionFlags)2147483648U);
					if (flag7)
					{
						num |= 4U;
					}
					else
					{
						num |= 2U;
					}
				}
				else
				{
					bool flag8 = characteristics.HasFlag((DataSectionFlags)2147483648U);
					if (flag8)
					{
						num |= 8U;
					}
					else
					{
						num |= 1U;
					}
				}
			}
			return num;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005390 File Offset: 0x00003590
		private bool ProcessSection(char[] name, IntPtr baseAddress, IntPtr remoteAddress, ulong rawData, ulong virtualAddress, ulong rawSize, ulong virtualSize, uint protectFlag)
		{
			UIntPtr uintPtr;
			bool flag = !Imports.WriteProcessMemory(this._hProcess, new IntPtr(remoteAddress.ToInt64() + (long)virtualAddress), new IntPtr(baseAddress.ToInt64() + (long)rawData), new IntPtr((long)rawSize), out uintPtr);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint num;
				bool flag2 = !Imports.VirtualProtectEx(this._hProcess, new IntPtr(remoteAddress.ToInt64() + (long)virtualAddress), new UIntPtr(virtualSize), protectFlag, out num);
				result = !flag2;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005414 File Offset: 0x00003614
		private bool ProcessSections(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				PIMAGE_SECTION_HEADER pimage_SECTION_HEADER = (PIMAGE_SECTION_HEADER)(ntHeader.Address + 24 + (int)ntHeader.Value.FileHeader.SizeOfOptionalHeader);
				for (ushort num = 0; num < ntHeader.Value.FileHeader.NumberOfSections; num += 1)
				{
					bool flag2 = Helpers._stricmp(".reloc".ToCharArray(), pimage_SECTION_HEADER[(uint)num].Name);
					if (!flag2)
					{
						DataSectionFlags characteristics = pimage_SECTION_HEADER[(uint)num].Characteristics;
						bool flag3 = characteristics.HasFlag(DataSectionFlags.MemoryRead) || characteristics.HasFlag((DataSectionFlags)2147483648U) || characteristics.HasFlag(DataSectionFlags.MemoryExecute);
						if (flag3)
						{
							uint sectionProtection = this.GetSectionProtection(pimage_SECTION_HEADER[(uint)num].Characteristics);
							this.ProcessSection(pimage_SECTION_HEADER[(uint)num].Name, baseAddress, remoteAddress, (ulong)pimage_SECTION_HEADER[(uint)num].PointerToRawData, (ulong)pimage_SECTION_HEADER[(uint)num].VirtualAddress, (ulong)pimage_SECTION_HEADER[(uint)num].SizeOfRawData, (ulong)pimage_SECTION_HEADER[(uint)num].VirtualSize, sectionProtection);
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005584 File Offset: 0x00003784
		private bool ExecuteRemoteThreadBuffer(byte[] threadData, bool async)
		{
			IntPtr lpAddress = this.RemoteAllocateMemory((uint)threadData.Length);
			bool flag = lpAddress == IntPtr.Zero;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				UIntPtr uintPtr;
				bool flag2 = Imports.WriteProcessMemory(this._hProcess, lpAddress, threadData, threadData.Length, out uintPtr);
				bool flag3 = flag2;
				if (flag3)
				{
					IntPtr hHandle = Imports.CreateRemoteThread(this._hProcess, IntPtr.Zero, 0U, lpAddress, IntPtr.Zero, 0U, IntPtr.Zero);
					if (async)
					{
						Thread thread = new Thread(delegate()
						{
							Imports.WaitForSingleObject(hHandle, 5000U);
							Imports.VirtualFreeEx(this._hProcess, lpAddress, 0, Imports.FreeType.Release);
						})
						{
							IsBackground = true
						};
						thread.Start();
					}
					else
					{
						Imports.WaitForSingleObject(hHandle, 4000U);
						Imports.VirtualFreeEx(this._hProcess, lpAddress, 0, Imports.FreeType.Release);
					}
				}
				result = flag2;
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005698 File Offset: 0x00003898
		private bool CallEntryPoint(IntPtr baseAddress, uint entrypoint, bool async)
		{
			List<byte> list = new List<byte>();
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(baseAddress.ToInt32()));
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(1));
			list.Add(104);
			list.AddRange(BitConverter.GetBytes(0));
			list.Add(184);
			list.AddRange(BitConverter.GetBytes(entrypoint));
			list.Add(byte.MaxValue);
			list.Add(208);
			list.Add(51);
			list.Add(192);
			list.Add(194);
			list.Add(4);
			list.Add(0);
			return this.ExecuteRemoteThreadBuffer(list.ToArray(), async);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005768 File Offset: 0x00003968
		private bool ProcessTlsEntries(IntPtr baseAddress, IntPtr remoteAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = ntHeader.Value.OptionalHeader.TLSTable.Size == 0U;
				if (flag2)
				{
					result = true;
				}
				else
				{
					PIMAGE_TLS_DIRECTORY32 pimage_TLS_DIRECTORY = (PIMAGE_TLS_DIRECTORY32)this.RvaToPointer(ntHeader.Value.OptionalHeader.TLSTable.VirtualAddress, baseAddress);
					bool flag3 = pimage_TLS_DIRECTORY == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = pimage_TLS_DIRECTORY.Value.AddressOfCallBacks == 0U;
						if (flag4)
						{
							result = true;
						}
						else
						{
							byte[] array = new byte[1020];
							UIntPtr uintPtr;
							bool flag5 = !Imports.ReadProcessMemory(this._hProcess, new IntPtr((long)((ulong)pimage_TLS_DIRECTORY.Value.AddressOfCallBacks)), array, out uintPtr);
							if (flag5)
							{
								result = false;
							}
							else
							{
								PDWORD pdword = new PDWORD(array);
								bool flag6 = true;
								uint num = 0U;
								while (pdword[num] > 0U)
								{
									flag6 = this.CallEntryPoint(remoteAddress, pdword[num], false);
									bool flag7 = !flag6;
									if (flag7)
									{
										break;
									}
									num += 1U;
								}
								result = flag6;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005898 File Offset: 0x00003A98
		private IntPtr LoadImageToMemory(IntPtr baseAddress)
		{
			PIMAGE_NT_HEADERS32 ntHeader = this.GetNtHeader(baseAddress);
			bool flag = ntHeader == null;
			IntPtr result;
			if (flag)
			{
				Debug.WriteLine("[LoadImageToMemory] Invalid Image: No IMAGE_NT_HEADERS");
				result = IntPtr.Zero;
			}
			else
			{
				bool flag2 = ntHeader.Value.FileHeader.NumberOfSections == 0;
				if (flag2)
				{
					Debug.WriteLine("[LoadImageToMemory] Invalid Image: No Sections");
					result = IntPtr.Zero;
				}
				else
				{
					uint num = uint.MaxValue;
					uint num2 = 0U;
					PIMAGE_SECTION_HEADER pimage_SECTION_HEADER = (PIMAGE_SECTION_HEADER)(ntHeader.Address + 24 + (int)ntHeader.Value.FileHeader.SizeOfOptionalHeader);
					for (uint num3 = 0U; num3 < (uint)ntHeader.Value.FileHeader.NumberOfSections; num3 += 1U)
					{
						bool flag3 = pimage_SECTION_HEADER[num3].VirtualSize == 0U;
						if (!flag3)
						{
							bool flag4 = pimage_SECTION_HEADER[num3].VirtualAddress < num;
							if (flag4)
							{
								num = pimage_SECTION_HEADER[num3].VirtualAddress;
							}
							bool flag5 = pimage_SECTION_HEADER[num3].VirtualAddress + pimage_SECTION_HEADER[num3].VirtualSize > num2;
							if (flag5)
							{
								num2 = pimage_SECTION_HEADER[num3].VirtualAddress + pimage_SECTION_HEADER[num3].VirtualSize;
							}
						}
					}
					uint size = num2 - num;
					bool flag6 = ntHeader.Value.OptionalHeader.ImageBase % 4096U > 0U;
					if (flag6)
					{
						Debug.WriteLine("[LoadImageToMemory] Invalid Image: Not Page Aligned");
						result = IntPtr.Zero;
					}
					else
					{
						bool flag7 = ntHeader.Value.OptionalHeader.DelayImportDescriptor.Size > 0U;
						if (flag7)
						{
							Debug.WriteLine("[LoadImageToMemory] This method is not supported for Managed executables");
							result = IntPtr.Zero;
						}
						else
						{
							IntPtr intPtr = this.RemoteAllocateMemory(size);
							bool flag8 = intPtr == IntPtr.Zero;
							if (flag8)
							{
								Debug.WriteLine("[LoadImageToMemory] Failed to allocate remote memory for module");
								result = IntPtr.Zero;
							}
							else
							{
								bool flag9 = !this.ProcessImportTable(baseAddress);
								if (flag9)
								{
									Debug.WriteLine("[LoadImageToMemory] Failed to fix imports");
									result = IntPtr.Zero;
								}
								else
								{
									bool flag10 = !this.ProcessDelayedImportTable(baseAddress, intPtr);
									if (flag10)
									{
										Debug.WriteLine("[LoadImageToMemory] Failed to fix delayed imports");
										result = IntPtr.Zero;
									}
									else
									{
										bool flag11 = !this.ProcessRelocations(baseAddress, intPtr);
										if (flag11)
										{
											Debug.WriteLine("[LoadImageToMemory] Failed to process relocations");
											result = IntPtr.Zero;
										}
										else
										{
											bool flag12 = !this.ProcessSections(baseAddress, intPtr);
											if (flag12)
											{
												Debug.WriteLine("[LoadImageToMemory] Failed to process sections");
												result = IntPtr.Zero;
											}
											else
											{
												bool flag13 = !this.ProcessTlsEntries(baseAddress, intPtr);
												if (flag13)
												{
													Debug.WriteLine("[LoadImageToMemory] ProcessTlsEntries Failed");
													result = IntPtr.Zero;
												}
												else
												{
													bool flag14 = ntHeader.Value.OptionalHeader.AddressOfEntryPoint > 0U;
													if (flag14)
													{
														int entrypoint = intPtr.ToInt32() + (int)ntHeader.Value.OptionalHeader.AddressOfEntryPoint;
														bool flag15 = !this.CallEntryPoint(intPtr, (uint)entrypoint, this.AsyncInjection);
														if (flag15)
														{
															Debug.WriteLine("[LoadImageToMemory] Failed to call entrypoint");
															return IntPtr.Zero;
														}
													}
													result = intPtr;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005BBC File Offset: 0x00003DBC
		private GCHandle PinBuffer(byte[] buffer)
		{
			return GCHandle.Alloc(buffer, GCHandleType.Pinned);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005BD8 File Offset: 0x00003DD8
		private void FreeHandle(GCHandle handle)
		{
			bool isAllocated = handle.IsAllocated;
			if (isAllocated)
			{
				handle.Free();
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005BFC File Offset: 0x00003DFC
		private void OpenTarget()
		{
			this._hProcess = Imports.OpenProcess(this._process, Imports.ProcessAccessFlags.All);
			bool flag = this._hProcess == IntPtr.Zero;
			if (flag)
			{
				throw new Exception(string.Format("Failed to open handle. Error {0}", Marshal.GetLastWin32Error()));
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005C50 File Offset: 0x00003E50
		private void CloseTarget()
		{
			bool flag = this._hProcess != IntPtr.Zero;
			if (flag)
			{
				Imports.CloseHandle(this._hProcess);
				this._hProcess = IntPtr.Zero;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005C8C File Offset: 0x00003E8C
		public IntPtr Inject(byte[] buffer)
		{
			GCHandle handle = default(GCHandle);
			buffer = buffer.ToArray<byte>();
			IntPtr result = IntPtr.Zero;
			try
			{
				bool flag = this._process == null || this._process.HasExited;
				if (flag)
				{
					return result;
				}
				handle = this.PinBuffer(buffer);
				this.OpenTarget();
				result = this.LoadImageToMemory(handle.AddrOfPinnedObject());
			}
			catch (Exception arg)
			{
				Debug.WriteLine(string.Format("Unexpected error {0}", arg));
			}
			finally
			{
				this.FreeHandle(handle);
				this.CloseTarget();
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005D40 File Offset: 0x00003F40
		public IntPtr Inject(string file)
		{
			return this.Inject(File.ReadAllBytes(file));
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000211C File Offset: 0x0000031C
		public ManualMapInjector(Process p)
		{
			this._process = p;
		}

		// Token: 0x04000022 RID: 34
		private readonly Process _process;

		// Token: 0x04000023 RID: 35
		private IntPtr _hProcess;
	}
}
