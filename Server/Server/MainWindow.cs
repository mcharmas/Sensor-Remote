using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace Server
{
    /// <summary>
    /// Main Window class.
    /// </summary>
    public partial class MainWindow : Form
    {        
        private Server s;        

        /// <summary>
        /// Initializes and starts server.
        /// Fills settings controls with settings values.        
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            servInit();
            s.start();
            updateStatusBar(false);

            textBoxIP.Text = Properties.Settings.Default.ip;
            textBox1.Text = Properties.Settings.Default.port.ToString();
            textBoxPassword.Text = Properties.Settings.Default.password;
            trackBarSensitivity.Value = 21 - (int)(Properties.Settings.Default.sensitivity * 10);
            trackBarScroll.Value = Properties.Settings.Default.scrollSpeed;

            checkBox1.Checked = Properties.Settings.Default.autohide;
            checkBox2.Checked = Util.IsAutoStartEnabled("Server", Assembly.GetExecutingAssembly().Location);

            radioButton2.Checked = Properties.Settings.Default.serialConnection;
            radioButton1.Checked = !Properties.Settings.Default.serialConnection;

            foreach (string st in SerialServer.getPorts())
            {
                comboBoxPort.Items.Add(st);
            }

            comboBoxPort.Text = Properties.Settings.Default.serialPort;

            foreach (string mp in MediaControler.players())
            {
                comboBoxMediaPlayer.Items.Add(mp);
            }
            comboBoxMediaPlayer.Text = Properties.Settings.Default.mediaPlayer;
        }

        /// <summary>
        /// Inits server.
        /// If settings.serialPort -> inits SerialServer
        /// Else -> inits TCPServer
        /// Connects event handlers (ClientConnectionChanged and ServerStatusChanged)
        /// </summary>
        private void servInit()
        {
            if (Properties.Settings.Default.serialConnection)
            {
                Console.WriteLine("Serial Server");
                s = new SerialServer(Properties.Settings.Default.serialPort);
            }
            else
            {
                Console.WriteLine("TCP Server");
                s = new TCPServer(Properties.Settings.Default.ip, Properties.Settings.Default.port);
            }

            s.cc += new ClientConnectionChanged(updateStatusBar);
            s.svc += new ServerStatusChanged(updateServerStatus);
        }

        /// <summary>
        /// Updates status bar information: client connected / no client connected.
        /// Connected to server delegates.
        /// </summary>
        /// <param name="stat">Bool value indicating if client is connected.</param>
        private void updateStatusBar(bool stat)
        {
            if (stat)
                connectionStatus.Text = "Client Connected";
            else
                connectionStatus.Text = "No Client Connected";
        }

        /// <summary>
        /// Updates server status in status bar, buttons and tray menu.
        /// Connected to server delegates.
        /// </summary>
        /// <param name="stat"></param>
        private void updateServerStatus(bool stat)
        {
            if (stat)
            {
                serverStatus.Text = "| Server is up";
                startButton.Text = "Stop Server";
                startToolStripMenuItem.Text = "Stop";
            }
            else
            {
                serverStatus.Text = "| Server is down";
                startButton.Text = "Start Server";
                startToolStripMenuItem.Text = "Start";
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        /// <summary>
        /// Overrided function. Stops the server on closing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            s.stop();
        }

        /// <summary>
        /// Method connected to startButton. Starts/Stops server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (s.isRunning())
                s.stop();

            else
            {
                servInit();
                s.start();
            }
        }

        /// <summary>
        /// Method connected with saveButton. Saves settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ip = textBoxIP.Text;
            try
            {
                Properties.Settings.Default.port = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong port number!");
            }
            Properties.Settings.Default.password = textBoxPassword.Text;
            Properties.Settings.Default.serialPort = comboBoxPort.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Method connected to sensitivity track bar. Stores value used by mouse mover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSensitivity_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.sensitivity = (21 - trackBarSensitivity.Value) / 10F;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Method connected with "Close" tray menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method connected with tray icon showing/hiding window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    Hide();
                }
                else
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        /// <summary>
        /// Method connected to "Start/Stop" button in tray menu. Calls startButton_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startButton_Click(null, null);
        }

        /// <summary>
        /// Method connected with autohide checkbox. Saves state in settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autohide = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Method connected with autostart checkbox. Calls Util.SetAutostart or UnSetAutostart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Util.SetAutoStart("Server", Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                Util.UnSetAutoStart("Server");
            }
        }

        /// <summary>
        /// Method connected with "server choice" radio button.
        /// Saves value in settings and shows/hides tcpipPanel or serialPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                tcpipPanel.Hide();
                serialPanel.Show();
                Properties.Settings.Default.serialConnection = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                tcpipPanel.Show();
                serialPanel.Hide();
                Properties.Settings.Default.serialConnection = false;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Hides window on start according to setting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autohide)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        /// <summary>
        /// Method connected with Scroll Speed track bar.
        /// Stores value in settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarScroll_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.scrollSpeed = trackBarScroll.Value;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Method connected with media player choose box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMediaPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mediaPlayer = comboBoxMediaPlayer.Text;
            Properties.Settings.Default.Save();
            s.stop();
            s.start();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
