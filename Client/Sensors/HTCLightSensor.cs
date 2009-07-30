using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile;
using Microsoft.WindowsMobile.Status;
using System.Threading;
using Microsoft.WindowsCE.Forms;

namespace Sensors
{
    public struct HTCLightSensorData
    {
        public int Reserved0; // this value is always 3
        public byte Luminance; // this value ranges between 0 and 30
    }

    class HTCLightSensor : LightSensorBase
    {
        #region HTCSensorSDK
        // The followign PInvoke is the results of reverse engineering done by Koushik Dutta
        // at www.koushikdutta.com
        [DllImport("HTCSensorSDK")]
        extern static IntPtr HTCSensorGetDataOutput(IntPtr handle, out HTCLightSensorData sensorData);
        #endregion

        public static HTCLightSensor Create()
        {
            return new HTCLightSensor(HTCNativeMethods.HTCSensorOpen(HTCSensor.Light));
        }

        private HTCLightSensor(IntPtr handle)
        {
            myHandle = handle;
        }

        IntPtr myHandle;
        public HTCLightSensorData GetRawSensorData()
        {
            HTCLightSensorData data;
            HTCSensorGetDataOutput(myHandle, out data);
            return data;
        }

        #region ILightSensor Members

        /// <summary>
        /// This method will return the luminance of the surrounding environment in view of the sensor.
        /// The return value will be in candela/m^2 (aka nit).
        /// </summary>
        /// <returns></returns>
        public override double GetLumens()
        {
            HTCLightSensorData data = GetRawSensorData();
            // Not really sure a good way to calibrate this.
            // Did it by holding it up to my 700 lumen lightbulb, and it returns ~208.
            return (double)data.Luminance * ((double)755 / (double)208);
        }

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (myHandle != IntPtr.Zero)
            {
                HTCNativeMethods.HTCSensorClose(myHandle);
                myHandle = IntPtr.Zero;
            }
        }

        #endregion
    }
}
