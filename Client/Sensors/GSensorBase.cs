using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.WindowsCE.Forms;

namespace Sensors
{
    abstract class GSensorBase : PollingSensor, IGSensor
    {
        public GSensorBase()
        {
            myOrientation = GetGVector().ToScreenOrientation();
        }

        public abstract GVector GetGVector();

        protected ScreenOrientation myOrientation;
        void GSensorThread()
        {
            ScreenOrientation lastOrientation = myOrientation;
            int difCount = 0;
            while (true)
            {
                try
                {
                    ScreenOrientation newOrientation = GetGVector().ToScreenOrientation();
                    if (newOrientation != lastOrientation)
                        difCount = 0;
                    lastOrientation = newOrientation;
                    if (newOrientation != myOrientation)
                        difCount++;
                    if (difCount > 2)
                    {
                        myOrientation = lastOrientation = newOrientation;
                        difCount = 0;
                        InvokeSensorMessage();
                    }

                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
            }
        }

        OrientationChangedHandler myOrientationChangedHandler;
        public event OrientationChangedHandler OrientationChanged
        {
            add
            {
                myOrientationChangedHandler += value;
                CreatePollingThreadIfNecessary(GSensorThread);
            }
            remove
            {
                myOrientationChangedHandler -= value;
                if (myOrientationChangedHandler == null)
                    CleanupPollingThread();
            }
        }


        #region IGSensor Members

        public ScreenOrientation Orientation
        {
            get
            {
                return GetGVector().ToScreenOrientation();
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            CleanupPollingThread();
        }

        ~GSensorBase()
        {
            Dispose(false);
        }

        protected override void OnSensorMessage()
        {
            if (myOrientationChangedHandler != null)
                myOrientationChangedHandler(this);
        }
    }
}
