using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Remote.Windows
{
    /// <summary>
    /// Window showing one of modules.
    /// Fullscreen windows, have back button.
    /// </summary>
    partial class ModuleWindow : Form
    {        
        /// <summary>
        /// Connect KeyEventHandlers.
        /// </summary>
        public ModuleWindow()
        {
            InitializeComponent();
            
            this.KeyDown += new KeyEventHandler(KeyHandler.KeyDown);
            this.KeyPress += new KeyPressEventHandler(KeyHandler.KeyPress);
        }

        /// <summary>
        /// Sets module on panel as main control.
        /// </summary>
        /// <param name="uc">control to be set</param>
        public void setModule(UserControl uc)
        {            
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);            
            this.Text = uc.Name;

            this.Focus();
        }        

        /// <summary>
        /// Back button function closing this window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}