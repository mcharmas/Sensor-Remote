using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Remote
{
    delegate void eventSender(string str);
    
    /// <summary>
    /// Touch pad controll.
    /// Panel sensible to touch and move sending mouse events.
    /// Supports clicking (when time between tapDown and tapUP is below 100ms).
    /// </summary>
    class TouchPad : Panel
    {
        public eventSender es = null;
        private int startX, startY;        
        private Timer t = new Timer();
        private int tics = 0;

        /// <summary>
        /// Sets time interval for timer measuring time between taps.
        /// </summary>
        public TouchPad()
        {
            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
        }

        /// <summary>
        /// This function increases tics used for time measuring.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void t_Tick(object sender, EventArgs e)
        {
            tics++;
        }       

        /// <summary>
        /// Overrided function.
        /// When tap - set startX and startY.
        /// Enables click timer.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
            t.Enabled = true;
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Stops timer. If time less than 100ms, sends click. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            t.Enabled = false;
                        
            if (tics <= 10)
            {
                es("LDOWN;LUP;");                
            }

            if (es != null)
            {
                es("0 0;");
            }
            tics = 0;
        }

        /// <summary>
        /// Handles Mouse move event.
        /// Sends mouse move event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int m = Math.Abs(startX - e.X);
            int n = Math.Abs(startY - e.Y);
            int moveX = Math.Sign(-(startX - e.X)) * m * 10;
            int moveY = Math.Sign(startY - e.Y) * n * 10;

            if (m > 0 && n > 0)
            {
                startX = e.X;
                startY = e.Y;
            }
            else
            {
                moveX = 0;
                moveY = 0;
            }
                        
            if (es != null)
            {
                es(moveX.ToString() + " " + moveY.ToString() + ";");
            }

            base.OnMouseMove(e);
        }
    }
}
