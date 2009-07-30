using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    enum HTCSensor : uint
    {
        Something = 0,
        GSensor = 1,
        Light = 2,
        Another = 3,
    }

    enum HTCAPIMode : uint
    {
        Gesture = 4
    }

    static class HTCNativeMethods
    {
        // The following PInvokes were ported from the results of the reverse engineering done
        // by Scott at scottandmichelle.net.
        // Blog post: http://scottandmichelle.net/scott/comments.html?entry=784
        [DllImport("HTCSensorSDK")]
        public extern static IntPtr HTCSensorOpen(HTCSensor sensor);

        [DllImport("HTCSensorSDK")]
        public extern static void HTCSensorClose(IntPtr handle);

        [DllImport("HTCAPI")]
        public extern static int HTCNavOpen(IntPtr hWnd, int api);

        [DllImport("HTCAPI")]
        public extern static int HTCNavSetMode(IntPtr hWnd, HTCAPIMode mode);

        [DllImport("HTCAPI")]
        public extern static int HTCNavClose(int api);

        public const int WM_HTCNAV = 0x0400 + 200;
        public const int HTCNavOpenAPI = 1;
    }
}
