using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.WindowsCE.Forms;

namespace Sensors
{
    /// <summary>
    /// This serves as a base class for any sensor that needs to do
    /// periodic polling.
    /// </summary>
    abstract class PollingSensor : IDisposable
    {
        SensorWindow myWindow;

        const int SensorMessage = 50000;
        class SensorWindow : MessageWindow
        {
            public SensorWindow(PollingSensor sensor)
            {
                mySensor = sensor;
            }
            public PollingSensor mySensor;
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == SensorMessage)
                    mySensor.OnSensorMessage();
                base.WndProc(ref m);
            }
        }

        protected void InvokeSensorMessage()
        {
            Message msg = new Message();
            msg.Msg = SensorMessage;
            msg.HWnd = myWindow.Hwnd;
            MessageWindow.SendMessage(ref msg);
        }

        protected abstract void OnSensorMessage();

        public PollingSensor()
        {
            myWindow = new SensorWindow(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            DoDispose(true);
        }

        #endregion

        Thread myThread;
        protected void CreatePollingThreadIfNecessary(ThreadStart threadStart)
        {
            if (myThread != null)
                return;
            myThread = new Thread(threadStart);
            myThread.IsBackground = true;
            myThread.Start();
        }

        protected void CleanupPollingThread()
        {
            if (myThread != null)
            {
                myThread.Abort();
                myThread = null;
            }
        }

        void DoDispose(bool disposing)
        {
            if (myIsDisposed)
                return;
            Dispose(disposing);
            myIsDisposed = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            CleanupPollingThread();
            if (myWindow != null)
            {
                myWindow.Dispose();
                myWindow = null;
            }
        }

        bool myIsDisposed = false;
        ~PollingSensor()
        {
            DoDispose(false);
        }
    }
}
