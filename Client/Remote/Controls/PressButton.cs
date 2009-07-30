using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Remote
{
    /// <summary>
    /// My press button class.
    /// Added command param to ease command sending.
    /// </summary>
    class PressButton: Button
    {
        private string cmd;
        private static bool lck;
        
        /// <summary>
        /// Parameter used in sending commands.
        /// When handling event ((PressButton)sender).command is used.
        /// </summary>
        public string command
        {
            get { return cmd; }
            set { cmd = value; }
        }

        /// <summary>
        /// Static parameter used when enter or space is pressed.
        /// Press button event handling function have
        /// if (PressButton.locked) clause not to process event when enter or space was pressed.
        /// Ugly solution - TODO.
        /// </summary>
        public static bool locked
        {
            get { return lck; }
            set { lck = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        //this doesn't work
        //marking KeyPressEvent as handled may do the thing...
        /*protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!lck)
            {
                base.OnKeyPress(e);
            }                       
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!lck)
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!lck)
            {
                base.OnKeyUp(e);
            }
        }*/

    }
}
