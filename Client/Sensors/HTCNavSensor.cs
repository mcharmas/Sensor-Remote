using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsCE.Forms;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sensors
{
    public class HTCNavSensor : INavSensor, IDisposable
    {
        enum WindowLong : int 
        {
            GWL_WNDPROC = -4,
        }

        int myLastTick = 0;
        int WndProc(IntPtr hWnd, int message, int wParam, int lParam)
        {
            try
            {
                if (message == HTCNativeMethods.WM_HTCNAV)
                {
                    int tickDelta = Environment.TickCount - myLastTick;
                    myLastTick = Environment.TickCount;
                    // after 1.5 seconds of no movement, we don't consider any RPS readings
                    // the elapsed time to be irrelevent.
                    // the tick delta will be set to 0, and the computer radial movement will be 0.
                    int tickTimeout = 1500;
                    if (tickDelta > tickTimeout)
                        tickDelta = 0;

                    bool positiveDirection = (wParam & 0x000000100) == 0;
                    int amount = wParam & 0x000000FF;
                    double rps = amount * 0.038910505836575875486381322957198;
                    if (!positiveDirection)
                        rps = -rps;
                    double radialDelta = rps * (double)tickDelta / 1000.0;
                    if (myRotated != null)
                        myRotated(rps, radialDelta);
                }
            }
            catch (Exception)
            {
            }
            return CallWindowProc(myOldWndProc, hWnd, message, wParam, lParam);
        }

        delegate int WndProcHandler(IntPtr hwnd, int message, int wParam, int lParam);

        [DllImport("coredll")]
        extern static IntPtr SetWindowLong(IntPtr hWnd, WindowLong windowLong, IntPtr newLong);

        [DllImport("coredll")]
        extern static int CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, int Msg, int wParam, int lParam);

        WndProcHandler myHandler;

        Form myForm;
        IntPtr myOldWndProc;
        public HTCNavSensor(Form form)
        {
            myHandler = new WndProcHandler(WndProc);
            myForm = form;
            myOldWndProc = SetWindowLong(form.Handle, WindowLong.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(myHandler));
            int ret = HTCNativeMethods.HTCNavOpen(form.Handle, HTCNativeMethods.HTCNavOpenAPI);
            ret = HTCNativeMethods.HTCNavSetMode(form.Handle, HTCAPIMode.Gesture);
        }



        #region IDisposable Members

        public void Dispose()
        {
            if (myOldWndProc != IntPtr.Zero && myForm != null)
            {
                SetWindowLong(myForm.Handle, WindowLong.GWL_WNDPROC, myOldWndProc);
                myOldWndProc = IntPtr.Zero;
            }
            HTCNativeMethods.HTCNavClose(HTCNativeMethods.HTCNavOpenAPI);
            myForm = null;
            myRotated = null;
        }

        #endregion

        #region INavSensor Members

        NavSensorMoveHandler myRotated;
        public event NavSensorMoveHandler Rotated
        {
            add
            {
                myRotated += value;
            }
            remove
            {
                myRotated -= value;
            }
        }

        #endregion
    }
}
