using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Types
{
	// Token: 0x02000037 RID: 55
	public class ManagedPtr<T> where T : struct
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002309 File Offset: 0x00000509
		public IntPtr Address { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00006594 File Offset: 0x00004794
		public T Value
		{
			get
			{
				return this[0U];
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000065B0 File Offset: 0x000047B0
		public int StructSize
		{
			get
			{
				bool flag = this._structSize == null;
				if (flag)
				{
					this._structSize = new int?(Marshal.SizeOf(typeof(T)));
				}
				return this._structSize.Value;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000065FC File Offset: 0x000047FC
		private static T GetStructure(IntPtr address)
		{
			return (T)((object)Marshal.PtrToStructure(address, typeof(T)));
		}

		// Token: 0x17000015 RID: 21
		public T this[uint index]
		{
			get
			{
				return ManagedPtr<T>.GetStructure(this.Address + (int)(index * (uint)this.StructSize));
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006650 File Offset: 0x00004850
		public static ManagedPtr<T>operator +(ManagedPtr<T> c1, int c2)
		{
			return new ManagedPtr<T>(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000667C File Offset: 0x0000487C
		public static ManagedPtr<T>operator ++(ManagedPtr<T> a)
		{
			return a + 1;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00006698 File Offset: 0x00004898
		public static ManagedPtr<T>operator -(ManagedPtr<T> c1, int c2)
		{
			return new ManagedPtr<T>(c1.Address - c2 * c1.StructSize);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000066C4 File Offset: 0x000048C4
		public static ManagedPtr<T>operator --(ManagedPtr<T> a)
		{
			return a - 1;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000066E0 File Offset: 0x000048E0
		public static explicit operator ManagedPtr<T>(IntPtr ptr)
		{
			bool flag = ptr == IntPtr.Zero;
			ManagedPtr<T> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new ManagedPtr<T>(ptr);
			}
			return result;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000670C File Offset: 0x0000490C
		public static explicit operator IntPtr(ManagedPtr<T> ptr)
		{
			return ptr.Address;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00002311 File Offset: 0x00000511
		public ManagedPtr(IntPtr address)
		{
			this.Address = address;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006724 File Offset: 0x00004924
		public ManagedPtr(object value, bool freeHandle = true)
		{
			bool flag = value == null;
			if (flag)
			{
				throw new InvalidOperationException("Cannot create a pointer of type null");
			}
			try
			{
				this._handle = GCHandle.Alloc(value, GCHandleType.Pinned);
			}
			catch (Exception)
			{
				throw new InvalidOperationException("Cannot create a pointer of type " + value.GetType().Name);
			}
			this._freeHandle = freeHandle;
			this.Address = this._handle.AddrOfPinnedObject();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000067A4 File Offset: 0x000049A4
		protected override void Finalize()
		{
			try
			{
				bool flag = this._handle.IsAllocated && this._freeHandle;
				if (flag)
				{
					this._handle.Free();
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x04000167 RID: 359
		private int? _structSize;

		// Token: 0x04000168 RID: 360
		private GCHandle _handle;

		// Token: 0x04000169 RID: 361
		private bool _freeHandle;
	}
}
