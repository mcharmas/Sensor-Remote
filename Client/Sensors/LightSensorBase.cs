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
    abstract class LightSensorBase : PollingSensor, ILightSensor
    {
        #region ILightSensor Members

        public abstract double GetLumens();

        public Brightness Brightness
        {
            get
            {
                return CalculateBrightness(GetLumens());
            }
        }

        int myCurrentSample = 0;
        double[] myBrightnessSamples = new double[5];
        Brightness myBrightness = Brightness.Dark;

        void BrightnessThread()
        {
            while (true)
            {
                myBrightnessSamples[myCurrentSample++] = GetLumens();
                myCurrentSample %= myBrightnessSamples.Length;
                Brightness currentBrightness = CalculateBrightness();
                if (currentBrightness != myBrightness)
                {
                    myBrightness = currentBrightness;
                    InvokeSensorMessage();
                }
                Thread.Sleep(1000);
            }
        }

        protected override void OnSensorMessage()
        {
            if (myBrightnessChanged != null)
                myBrightnessChanged(this);
        }

        Brightness CalculateBrightness()
        {
            double total = 0;
            for (int i = 0; i < myBrightnessSamples.Length; i++)
            {
                total += myBrightnessSamples[i];
            }
            total /= myBrightnessSamples.Length;
            if (total < 20)
                return Brightness.Dark;
            if (total < 80)
                return Brightness.Dim;
            if (total < 300)
                return Brightness.Normal;
            return Brightness.Bright;
        }

        static Brightness CalculateBrightness(double lumens)
        {
            if (lumens < 20)
                return Brightness.Dark;
            if (lumens < 80)
                return Brightness.Dim;
            if (lumens < 300)
                return Brightness.Normal;
            return Brightness.Bright;
        }

        BrightnessChangedHandler myBrightnessChanged;
        public event BrightnessChangedHandler BrightnessChanged
        {
            add
            {
                myBrightnessChanged += value;
                CreatePollingThreadIfNecessary(BrightnessThread);
            }
            remove
            {
                myBrightnessChanged -= value;
                if (myBrightnessChanged == null)
                    CleanupPollingThread();
            }
        }

        #endregion
    }
}
