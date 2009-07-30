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
    /// Utils module class. (arrow keys, enter, pgup, pgdn, esc, close)
    /// </summary>
    partial class UtilsTab : UserControl
    {
        public sendFunction send = null;
        public UtilsTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// All PressButtons are binded to this function.
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
