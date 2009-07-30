using System;
using System.Collections.Generic;
using System.Text;

namespace Sensors
{
    public enum Brightness
    {
        Dark,
        Dim,
        Normal,
        Bright
    }

    public delegate void BrightnessChangedHandler(ILightSensor sender);

    public interface ILightSensor : IDisposable
    {
        double GetLumens();
        Brightness Brightness
        {
            get;
        }
        event BrightnessChangedHandler BrightnessChanged;
    }

    public static class LightSensorFactory
    {
        public static ILightSensor CreateLightSensor()
        {
            try
            {
                return HTCLightSensor.Create();
            }
            catch (Exception)
            {
            }

            try
            {
                return SamsungLightSensor.Create();
            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}
