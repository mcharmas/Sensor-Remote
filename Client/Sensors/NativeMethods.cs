using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    enum ECreationDisposition : uint
    {
        New = 1,
        CreateAlways = 2,
        OpenExisting = 3,
        OpenAlways = 4,
        TruncateExisting = 5
    }

    static class NativeMethods
    {
        [DllImport("coredll")]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("coredll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DeviceIoControl(IntPtr hDevice, int dwIoControlCode, [In] int[] inBuffer, int nInBufferSize, [Out] int[] outBuffer, int nOutBufferSize, ref int pBytesReturned, IntPtr lpOverlapped);

        [DllImport("coredll")]
        public extern static IntPtr CreateFile(string filename, int desiredAccess, int shareMode, IntPtr securityAttributes, ECreationDisposition creationDisposition, int flags, IntPtr template);
    }
}
