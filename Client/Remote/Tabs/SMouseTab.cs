using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sensors;
using Microsoft.WindowsCE.Forms;

namespace Remote
{
    /// <summary>
    /// Mouse module class.
    /// </summary>
    partial class SMouseTab : UserControl
    {
        public sendFunction send = null;
        public vibrateFunction vibrate = null;

        private IGSensor sensor = GSensorFactory.CreateGSensor();        
        private int x = 0;
        private int y = 0;
        private bool scroll;

        public SMouseTab()
        {
            InitializeComponent();
            this.Text = "Mouse";            
        }

        /// <summary>
        /// All command buttons are binded to this function.
        /// Sends PressButton.command to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandButtonClicked(object sender, EventArgs e)
        {
            if (send != null && !PressButton.locked)
            {
                send(((PressButton)sender).command);
            }
            PressButton.locked = false;
        }

        /// <summary>
        /// Mouse move sensor timer tick function.
        /// Sends x and y acceleration.
        /// Screen orientation aware (swaps x and y values on landscape).
        /// Supports invert Y setting.
        /// Supports scrolling when scroll button is being held.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {            
            if (x != (int)(sensor.GetGVector().X * 10) || y != (int)(sensor.GetGVector().Y * 10))
            {
                x = (int)(sensor.GetGVector().X * 10);
                y = (int)(sensor.GetGVector().Y * 10);
                if (Convert.ToBoolean((string)Settings.get("invertY")))
                {
                    y = -y;
                }
                
                if (SystemSettings.ScreenOrientation == Microsoft.WindowsCE.Forms.ScreenOrientation.Angle180 || SystemSettings.ScreenOrientation == Microsoft.WindowsCE.Forms.ScreenOrientation.Angle270)
                {
                    
                    int z = x;
                    x = y;
                    y = z;
                    y = -y;
                }

                string data;
                if (scroll)
                    data = "SCROLL " + y.ToString() + ";";
                else
                    data = x.ToString() + " " + y.ToString() + ";";

                if (send != null)
                {
                    send(data);
                }

            }
        }

        /// <summary>
        /// Left / Right / Middle and Scroll button down function.
        /// Starts timer.
        /// If scroll sets scroll indicator used by timer tic function.
        /// Sends MyButton.down command.
        /// If vibrate handler is provided - vibrates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDown(object sender, MouseEventArgs e)
        {
            if (sender.Equals(scrollButton))
            {
                scroll = true;
            }

            if (((MyButton)sender).downCommand != "")
            {
                if (send != null)
                {
                    send(((MyButton)sender).downCommand);
                }
            }

            timer.Enabled = true;

            if (vibrate != null)
            {
                vibrate();
            }
        
        }

        /// <summary>
        /// Left / Right / Middle / Scroll button up function.
        /// Turns of timer.
        /// Sends MyButton.upCommand
        /// Sends "0 0;" to stop the mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUp(object sender, MouseEventArgs e)
        {
            if (sender.Equals(scrollButton))
            {
                scroll = false;
            }

            if (((MyButton)sender).upCommand != "")
            {
                if (send != null)
                {
                    send(((MyButton)sender).upCommand);
                }
            }

            timer.Enabled = false;
            if (send != null)
            {
                send("0 0;");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }        
    }
}
