using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Remote
{
    /// <summary>
    /// Form to edit settings.
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Initializes component with settings stored in registry.
        /// </summary>
        public SettingsForm()
        {            
            InitializeComponent();
            
            foreach (string s in SerialClient.getPorts())
            {
                comboBoxPorts.Items.Add(s);
            }

            try
            {
                textBoxIP.Text = (string)Settings.get("ip");
                textBoxPort.Text = (string)Settings.get("port");
                textBoxPassword.Text = (string)Settings.get("password");
                checkBoxVibrate.Checked = Convert.ToBoolean((string)Settings.get("vibrate"));
                checkBoxConnect.Checked = Convert.ToBoolean((string)Settings.get("startConnect"));
                checkBoxInvert.Checked = Convert.ToBoolean((string)Settings.get("invertY"));

                radioButtonSerial.Checked = Convert.ToBoolean((string)Settings.get("sConn"));
                radioButtonTCP.Checked = !Convert.ToBoolean((string)Settings.get("sConn"));
                comboBoxPorts.Text = (string)Settings.get("sPort");                
            }
            catch (Exception)
            {
            }


            
        }

        /// <summary>
        /// Saves settings and closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            Settings.save("ip", textBoxIP.Text);
            Settings.save("port", textBoxPort.Text);
            Settings.save("password", textBoxPassword.Text);
            Settings.save("vibrate", checkBoxVibrate.Checked);
            Settings.save("startConnect", checkBoxConnect.Checked);
            Settings.save("sConn", radioButtonSerial.Checked);
            Settings.save("sPort", comboBoxPorts.Text);
            Settings.save("invertY", checkBoxInvert.Checked);
            
            this.Close();
        }

        /// <summary>
        /// Closes window without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Shows / hides TCP/IP  /  Serial connection panels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                panelSerial.Hide();
                panelTCP.Show();
            }
            else
            {
                panelSerial.Show();
                panelTCP.Hide();
            }
        }
    }
}