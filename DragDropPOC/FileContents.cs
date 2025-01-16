using System;
using System.Runtime.InteropServices;
using System.IO;

// For detailed explanation, refer to CodeProject's example at https://www.codeproject.com/Articles/28209/Outlook-Drag-and-Drop-in-Csharp

namespace DragDropPOC
{
    public static class FileContents
    {
        [DllImport("OLE32.DLL", PreserveSig = false)]
        public static extern ILockBytes CreateILockBytesOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease);

        [DllImport("OLE32.DLL", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern IStorage StgCreateDocfileOnILockBytes(ILockBytes plkbyt, uint grfMode, uint reserved);

        [ComImport, Guid("0000000A-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ILockBytes
        {
            void ReadAt([In, MarshalAs(UnmanagedType.U8)] long ulOffset, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, [In, MarshalAs(UnmanagedType.U4)] int cb, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pcbRead);
            void WriteAt([In, MarshalAs(UnmanagedType.U8)] long ulOffset, IntPtr pv, [In, MarshalAs(UnmanagedType.U4)] int cb, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pcbWritten);
            void Flush();
            void SetSize([In, MarshalAs(UnmanagedType.U8)] long cb);
            void LockRegion([In, MarshalAs(UnmanagedType.U8)] long libOffset, [In, MarshalAs(UnmanagedType.U8)] long cb, [In, MarshalAs(UnmanagedType.U4)] int dwLockType);
            void UnlockRegion([In, MarshalAs(UnmanagedType.U8)] long libOffset, [In, MarshalAs(UnmanagedType.U8)] long cb, [In, MarshalAs(UnmanagedType.U4)] int dwLockType);
            void Stat([Out] out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, [In, MarshalAs(UnmanagedType.U4)] int grfStatFlag);
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000000B-0000-0000-C000-000000000046")]
        public interface IStorage
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            System.Runtime.InteropServices.ComTypes.IStream CreateStream([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, [In, MarshalAs(UnmanagedType.U4)] int grfMode, [In, MarshalAs(UnmanagedType.U4)] int reserved1, [In, MarshalAs(UnmanagedType.U4)] int reserved2);
            [return: MarshalAs(UnmanagedType.Interface)]
            System.Runtime.InteropServices.ComTypes.IStream OpenStream([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr reserved1, [In, MarshalAs(UnmanagedType.U4)] int grfMode, [In, MarshalAs(UnmanagedType.U4)] int reserved2);
            [return: MarshalAs(UnmanagedType.Interface)]
            IStorage CreateStorage([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, [In, MarshalAs(UnmanagedType.U4)] int grfMode, [In, MarshalAs(UnmanagedType.U4)] int reserved1, [In, MarshalAs(UnmanagedType.U4)] int reserved2);
            [return: MarshalAs(UnmanagedType.Interface)]
            IStorage OpenStorage([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr pstgPriority, [In, MarshalAs(UnmanagedType.U4)] int grfMode, IntPtr snbExclude, [In, MarshalAs(UnmanagedType.U4)] int reserved);
            void CopyTo(int ciidExclude, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] pIIDExclude, IntPtr snbExclude, [In, MarshalAs(UnmanagedType.Interface)] IStorage stgDest);
            void MoveElementTo([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, [In, MarshalAs(UnmanagedType.Interface)] IStorage stgDest, [In, MarshalAs(UnmanagedType.BStr)] string pwcsNewName, [In, MarshalAs(UnmanagedType.U4)] int grfFlags);
            void Commit(int grfCommitFlags);
            void Revert();
            void EnumElements([In, MarshalAs(UnmanagedType.U4)] int reserved1, IntPtr reserved2, [In, MarshalAs(UnmanagedType.U4)] int reserved3, [MarshalAs(UnmanagedType.Interface)] out object ppVal);
            void DestroyElement([In, MarshalAs(UnmanagedType.BStr)] string pwcsName);
            void RenameElement([In, MarshalAs(UnmanagedType.BStr)] string pwcsOldName, [In, MarshalAs(UnmanagedType.BStr)] string pwcsNewName);
            void SetElementTimes([In, MarshalAs(UnmanagedType.BStr)] string pwcsName, [In] System.Runtime.InteropServices.ComTypes.FILETIME pctime, [In] System.Runtime.InteropServices.ComTypes.FILETIME patime, [In] System.Runtime.InteropServices.ComTypes.FILETIME pmtime);
            void SetClass([In] ref Guid clsid);
            void SetStateBits(int grfStateBits, int grfMask);
            void Stat([Out] out System.Runtime.InteropServices.ComTypes.STATSTG pStatStg, int grfStatFlag);
        }

        public static byte[] GetFileContents(System.Windows.Forms.IDataObject data, int index)
        {
            System.Runtime.InteropServices.ComTypes.IDataObject comdata = (System.Runtime.InteropServices.ComTypes.IDataObject)data;
            System.Runtime.InteropServices.ComTypes.FORMATETC fmt = new System.Runtime.InteropServices.ComTypes.FORMATETC();

            fmt.cfFormat = (short)System.Windows.Forms.DataFormats.GetFormat("FileContents").Id;
            fmt.dwAspect = System.Runtime.InteropServices.ComTypes.DVASPECT.DVASPECT_CONTENT;
            fmt.lindex = index;
            fmt.ptd = new IntPtr(0);
            fmt.tymed = System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTREAM | System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTORAGE | System.Runtime.InteropServices.ComTypes.TYMED.TYMED_HGLOBAL;

            System.Runtime.InteropServices.ComTypes.STGMEDIUM med = new System.Runtime.InteropServices.ComTypes.STGMEDIUM();
            comdata.GetData(ref fmt, out med);

            if (med.tymed == System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTREAM)
                return GetContents_ISTREAM(med);
            else if (med.tymed == System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTORAGE)
                return GetContents_ISTORAGE(med);
            else if (med.tymed == System.Runtime.InteropServices.ComTypes.TYMED.TYMED_HGLOBAL)
                return GetContents_HGLOBAL(med, data);

            return new byte[0];
        }

        private static byte[] GetContents_ISTREAM(System.Runtime.InteropServices.ComTypes.STGMEDIUM med)
        {
            System.Runtime.InteropServices.ComTypes.IStream str = (System.Runtime.InteropServices.ComTypes.IStream)Marshal.GetObjectForIUnknown(med.unionmember);
            Marshal.Release(med.unionmember);

            System.Runtime.InteropServices.ComTypes.STATSTG strstat = new System.Runtime.InteropServices.ComTypes.STATSTG();
            str.Stat(out strstat, 0);

            byte[] content = new byte[strstat.cbSize];
            str.Read(content, content.Length, IntPtr.Zero);

            return content;
        }

        private static byte[] GetContents_ISTORAGE(System.Runtime.InteropServices.ComTypes.STGMEDIUM med)
        {
            IStorage is1 = null;
            IStorage is2 = null;
            ILockBytes lockbytes = null;
            System.Runtime.InteropServices.ComTypes.STATSTG lockbytesstat;
            byte[] content = new byte[0];

            try
            {
                is1 = (IStorage)Marshal.GetObjectForIUnknown(med.unionmember);
                Marshal.Release(med.unionmember);
                lockbytes = CreateILockBytesOnHGlobal(IntPtr.Zero, true);
                is2 = StgCreateDocfileOnILockBytes(lockbytes, 0x00001012, 0);

                is1.CopyTo(0, null, IntPtr.Zero, is2);
                lockbytes.Flush();
                is2.Commit(0);

                lockbytesstat = new System.Runtime.InteropServices.ComTypes.STATSTG();
                lockbytes.Stat(out lockbytesstat, 1);

                content = new byte[lockbytesstat.cbSize];
                lockbytes.ReadAt(0, content, content.Length, null);
            }
            finally
            {
                Marshal.ReleaseComObject(is2);
                Marshal.ReleaseComObject(lockbytes);
                Marshal.ReleaseComObject(is1);
            }

            return content;
        }

        private static byte[] GetContents_HGLOBAL(System.Runtime.InteropServices.ComTypes.STGMEDIUM med, System.Windows.Forms.IDataObject data)
        {
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            System.Reflection.FieldInfo fi = data.GetType().GetField("innerData", flags);
            System.Windows.Forms.IDataObject ndata = (System.Windows.Forms.IDataObject)fi.GetValue(data);
            System.Reflection.MethodInfo m = ndata.GetType().GetMethod("GetDataFromHGLOBAL", flags);

            MemoryStream ms = (MemoryStream)m.Invoke(ndata, new object[] { "FileContents", med.unionmember });
            byte[] content = new byte[ms.Length];

            ms.Read(content, 0, content.Length);

            ms.Close();
            ms.Dispose();

            return content;
        }
    }
}
