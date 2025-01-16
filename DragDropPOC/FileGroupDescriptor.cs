using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace DragDropPOC
{
    public static class FileGroupDescriptor
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private sealed class FGDescriptor
        {
            public uint cItems;
            public FDescriptor[] fgd;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private sealed class FDescriptor
        {
            public uint dwFlags;
            public Guid clsid;
            public Size size1;
            public Point pointl;
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
        }

        public static string[] GetFileNames(MemoryStream ms)
        {
            byte[] data = new byte[ms.Length];
            ms.Read(data, 0, data.Length);

            IntPtr fgdptr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, fgdptr, data.Length);

            FGDescriptor fgdesc = (FGDescriptor)Marshal.PtrToStructure(fgdptr, typeof(FGDescriptor));
            string[] filenames = new string[fgdesc.cItems];

            IntPtr fdptr = (IntPtr)((int)fgdptr + Marshal.SizeOf(fgdptr));
            FDescriptor fd;

            for (int i = 0; i < fgdesc.cItems; i++)
            {
                fd = (FDescriptor)Marshal.PtrToStructure(fdptr, typeof(FDescriptor));
                filenames[i] = fd.cFileName;

                fdptr = (IntPtr)((int)fdptr + Marshal.SizeOf(fd));
            }

            return filenames;
        }
    }
}
