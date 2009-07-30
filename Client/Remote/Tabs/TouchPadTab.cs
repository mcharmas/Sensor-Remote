using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Remote
{
    /// <summary>
    /// Touch Pad module class.
    /// </summary>
    partial class TouchPadTab : UserControl
    {
        public sendFunction send = null;

        public TouchPadTab()
        {
            InitializeComponent();
            touchPad1.es = new eventSender(s);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        /// <summary>
        /// Send function wrapper used to delegate it to touchPad object as eventSender.
        /// </summary>
        /// <param name="str"></param>
        public void s(string str)
        {
            if(send!=null)
            {
                send(str);
            }
        }

        /// <summary>
        /// All PressButtons are binded to this function.
        /// Sends PressButton.command to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandButtonClick(object sender, EventArgs e)
        {
            if (send != null && !PressButton.locked)
            {
                send(((PressButton)sender).command);
            }
            PressButton.locked = false;
        }
     
    }
}
