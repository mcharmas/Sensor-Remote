using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.WindowsCE.Forms;

namespace Sensors
{
    class SamsungGSensor : GSensorBase
    {
        public static SamsungGSensor Create()
        {
            DeviceIoControl(ACCOnRot, new int[1] { 0 }, new int[1] { 0 });
            return new SamsungGSensor();
        }

        private SamsungGSensor()
        {
        }

        static void DeviceIoControl(int controlCode, int[] inBuffer, int[] outBuffer)
        {
            IntPtr file = NativeMethods.CreateFile("ACS1:", 0, 0, IntPtr.Zero, ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
            if (file == (IntPtr)(-1))
                throw new InvalidOperationException("Unable to Create File");

            try
            {
                int bytesReturned = 0;
                int inSize = sizeof(int) * inBuffer.Length;
                int outSize = sizeof(int) * outBuffer.Length;
                if (!NativeMethods.DeviceIoControl(file, controlCode, inBuffer, inSize, outBuffer, outSize, ref bytesReturned, IntPtr.Zero))
                    throw new InvalidOperationException("Unable to perform operation.");
            }
            finally
            {
                NativeMethods.CloseHandle(file);
            }
        }

        const int ACCOnRot = 0x44E;
        const int ACCOffRot = 0x44F;
        const int ACCReadValues = 0x3F7;

        #region IGSensor Members

        public override GVector GetGVector()
        {
            int[] outBuffer = new int[3];
            DeviceIoControl(ACCReadValues, new int[1] { 0 }, outBuffer);

            GVector ret = new GVector();
            ret.X = outBuffer[1];
            ret.Y = outBuffer[0];
            ret.Z = -outBuffer[2];
            double samsungScaleFactor = 1.0 / 1000.0 * 9.8 * 3.3793103448275862068965517241379;
            return ret.Scale(samsungScaleFactor);
        }

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            DeviceIoControl(ACCOffRot, new int[1] { 0 }, new int[1] { 0 });
        }

        #endregion
    }
}