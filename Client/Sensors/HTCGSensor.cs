using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.WindowsMobile.Status;

namespace Sensors
{
    struct HTCGSensorData
    {
        public short TiltX;          // From -1000 to 1000 (about), 0 is flat
        public short TiltY;          // From -1000 to 1000 (about), 0 is flat
        public short TiltZ;          // From -1000 to 1000 (about), 0 = Straight up, -1000 = Flat, 1000 = Upside down
        public short Unknown1;       // Always zero
        public int AngleY;         // From 0 to 359
        public int AngleX;         // From 0 to 359
        public int Unknown2;       // Bit field?
    };

    class HTCGSensor : GSensorBase
    {
        // The following PInvoke was ported from the results of the reverse engineering done
        // by Scott at scottandmichelle.net.
        // Blog post: http://scottandmichelle.net/scott/comments.html?entry=784
        [DllImport("HTCSensorSDK")]
        extern static IntPtr HTCSensorGetDataOutput(IntPtr handle, out HTCGSensorData sensorData);

        IntPtr myHandle;
        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (myHandle != IntPtr.Zero)
            {
                HTCNativeMethods.HTCSensorClose(myHandle);
                myHandle = IntPtr.Zero;
            }

            // note: I noticed in Scott's code, on the shutdown he fires the "HTC_GSENSOR_SERVICESTART" event again.
            // I am guessing that is a bug in his code.
            // My theory is the service start/stop manage a reference count to the service.
            // Once it hits 0, the service is stopped.
            IntPtr hEvent = CreateEvent(IntPtr.Zero, true, false, "HTC_GSENSOR_SERVICESTOP");
            SetEvent(hEvent);
            CloseHandle(hEvent);
        }

        #endregion

        [DllImport("coredll")]
        extern static bool CloseHandle(IntPtr handle);

        [DllImport("coredll", SetLastError = true)]
        extern static IntPtr CreateEvent(IntPtr eventAttributes, bool manualReset, bool intialState, string name);

        [DllImport("coredll", SetLastError = true)]
        extern static bool EventModify(IntPtr handle, uint func);
        //#define SENSOR_START        _T("HTC_GSENSOR_SERVICESTART")
        //#define SENSOR_STOP         _T("HTC_GSENSOR_SERVICESTOP")

        static bool SetEvent(IntPtr handle)
        {
            return EventModify(handle, 3);
        }

        public HTCGSensorData GetRawSensorData()
        {
            HTCGSensorData data;
            HTCSensorGetDataOutput(myHandle, out data);
            return data;
        }

        public static HTCGSensor Create()
        {
            IntPtr hEvent = CreateEvent(IntPtr.Zero, true, false, "HTC_GSENSOR_SERVICESTART");
            SetEvent(hEvent);
            CloseHandle(hEvent);
            IntPtr handle = HTCNativeMethods.HTCSensorOpen(HTCSensor.GSensor);
            return new HTCGSensor(handle);
        }

        private HTCGSensor(IntPtr handle)
        {
            myHandle = handle;
        }

        #region ISensor Members

        public override GVector GetGVector()
        {
            GVector ret = new GVector();
            HTCGSensorData data = GetRawSensorData();
            ret.X = data.TiltX;
            ret.Y = data.TiltY;
            ret.Z = data.TiltZ;
            // HTC's Sensor returns a vector which is around 1000 in length on average..
            // but it really depends on how the device is oriented.
            // When simply face up, my Diamond returns a vector of around 840 in length.
            // While face down, it returns a vector of around 1200 in length.
            // The vector direction is fairly accurate, however, the length is clearly not extremely precise.
            double htcScaleFactor = 1.0 / 1000.0 * 9.8;
            return ret.Scale(htcScaleFactor);
        }

        #endregion
    }
}
