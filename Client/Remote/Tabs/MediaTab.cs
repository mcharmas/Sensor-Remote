using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sensors;

namespace Remote
{
    /// <summary>
    /// Media module. Sends "MEDIA" commands.
    /// </summary>
    partial class MediaTab : UserControl
    {
        private IGSensor sensor = GSensorFactory.CreateGSensor();
        public sendFunction send = null;
        
        public MediaTab()
        {
            InitializeComponent();
            this.Text = "Media";
        }

        /// <summary>
        /// All PressButtons are binded to this function.
        /// After clicking PressButton.command is sent to server.
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
        /// Vol sensor panel tap down function.
        /// Starts timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volButton_MouseDown(object sender, MouseEventArgs e)
        {
            volTimer.Enabled = true;
            volTimer.Interval = 100;
        }

        /// <summary>
        /// Vol sensor panel tap up function.
        /// Stops timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volButton_MouseUp(object sender, MouseEventArgs e)
        {
            volTimer.Enabled = false;
        }

        /// <summary>
        /// Vol sensor panel timer tick.
        /// Changes interval depending on phone position.
        /// Sends MEDIA VOLUP and MEDIA VOLDOWN commands.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volTimer_Tick(object sender, EventArgs e)
        {         
            if (sensor.GetGVector().X < -1)
            {                
                send("MEDIA VOLDOWN;");
                volTimer.Interval = (int)(Math.Abs(800 / sensor.GetGVector().X));
            }
            else if (sensor.GetGVector().X > 1)
            {
                send("MEDIA VOLUP;");
                volTimer.Interval = (int)(Math.Abs(800 / sensor.GetGVector().X));
            }                                
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
