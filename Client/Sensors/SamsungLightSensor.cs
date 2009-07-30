using System;

using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    class SamsungLightSensor : LightSensorBase
    {
        public static SamsungLightSensor Create()
        {
            GetLumensInternal();
            return new SamsungLightSensor();
        }

        private SamsungLightSensor()
        {
        }

        public static double[] myLumensMapping = new double[15] { 0, 1, 3, 10, 30, 50, 75, 115, 150, 185, 220, 255, 290, 325, 350 };

        static double GetLumensInternal()
        {
            IntPtr file = NativeMethods.CreateFile("BKL1:", 0, 0, IntPtr.Zero, ECreationDisposition.OpenExisting, 0, IntPtr.Zero);
            if (file == (IntPtr)(-1))
                throw new InvalidOperationException("Unable to Create File");

            int[] inBuffer = new int[1];
            int[] outBuffer = new int[1];
            const int IOCTL_LIGHT_GET = 0x220004;
            try
            {
                int bytesReturned = 0;
                int inSize = sizeof(int) * inBuffer.Length;
                int outSize = sizeof(int) * outBuffer.Length;
                if (!NativeMethods.DeviceIoControl(file, IOCTL_LIGHT_GET, inBuffer, inSize, outBuffer, outSize, ref bytesReturned, IntPtr.Zero))
                    throw new InvalidOperationException("Unable to perform operation.");
            }
            finally
            {
                NativeMethods.CloseHandle(file);
            }

            return myLumensMapping[outBuffer[0]];
        }

        public override double GetLumens()
        {
            return GetLumensInternal();
        }
    }
}
