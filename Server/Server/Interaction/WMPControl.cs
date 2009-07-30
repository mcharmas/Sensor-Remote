using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    /// <summary>
    /// Class implementing IMediaPlayer used to control windows media player application.
    /// </summary>
    class WMPControl: IMediaPlayer
    {
        //stores WMP window handler
        System.Int32 iHandle;

        /// <summary>
        /// Search for WMP window and store the pointer in iHandle.
        /// When WMP is not running - starts it.
        /// </summary>
        private void findWindow()
        {
            iHandle = Win32.FindWindow("WMPlayerApp", "Windows Media Player");
            if (iHandle == 0)
            {
                System.Diagnostics.Process.Start("C://Program Files//windows Media Player//wmplayer.exe");
            }
        }

        #region IMediaPlayer Members

        public void play()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004978, 0x00000000);
        }

        public void pause()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004978, 0x00000000);
        }

        public void stop()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004979, 0x00000000);
        }

        public void next()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0000497B, 0x00000000);
        }

        public void prev()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0000497A, 0x00000000);
        }

        public void VolUP()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0000497F, 0x00000000);
        }

        public void VolDown()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004980, 0x00000000);
        }

        public void mute()
        {
            findWindow();
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004981, 0x00000000);
        }

        #endregion
    }
}
