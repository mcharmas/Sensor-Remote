using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sensors;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using Remote.Windows;

namespace Remote
{
    delegate void sendFunction(string str);
    delegate void vibrateFunction();

    /// <summary>
    /// Main  Window Class
    /// </summary>
    public partial class MainWindow : Form
    {
        Client c = null;
        
        /// <summary>
        /// Struct used for vibrate.
        /// </summary>
        struct NLED_SETTINGS_INFO
        {
            public int LedNum;

            public int OffOnBlink;

            public int TotalCycleTime;

            public int OnTime;
            public int OffTime;

            public int MetaCycleOn;
            public int MetaCycleOff;
        }

        /// <summary>
        /// Vibrate device is led. This unmanaged function turn's on / off led.
        /// </summary>
        /// <param name="deviceId">Physical ID of the LED you wish to access.  For vibrate it is generally ID 1.</param>
        /// <param name="info">Led settings.</param>
        /// <returns></returns>
        [DllImport("Coredll")]
        extern static bool NLedSetDevice(int deviceId, ref NLED_SETTINGS_INFO info);
        
        /// <summary>
        /// Vibrate function using unmanaged NLedSetDevice function.
        /// </summary>
        /// <param name="state">true - turns on vibrate / false - turns off.</param>
        static void SetVibrate(bool state)
        {
            // Instantiate a new object from the structure we created
            NLED_SETTINGS_INFO info = new NLED_SETTINGS_INFO();

            // Sets the LED number to be used, this is based on the LED device 
            // capabilities but in the case of virbation shouldn't matter.
            info.LedNum = 1;

            // sets the state of the LED, with vibrate it can only be on or off 
            // but a value of 2 for blink can base used in other cases
            info.OffOnBlink = state ? 1 : 0;

            // Actually sets the device to enable vibration or disable it. the 1 subsection is the DeviceID, 
            // in this case and most phone cases this will be device 1, the second subsection is passing the
            // information from the info structure.
            NLedSetDevice(1, ref info);
        }
               
        /// <summary>
        /// Initializes KeyHandler which is used to send physicall buttons actions.
        /// Calls initClient.
        /// Connects according to startConnect setting.        
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            initClient();
            KeyHandler.sw += new sendFunction(send);
            this.KeyDown += new KeyEventHandler(KeyHandler.KeyDown);
            this.KeyPress += new KeyPressEventHandler(KeyHandler.KeyPress);        

            try
            {
                if (Convert.ToBoolean((string)Settings.get("startConnect")))
                {
                    menuItemConnect_Click(null, null);
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Wrong settings.");
                (new SettingsForm()).Show();
            }
            catch (Exception)
            {
            }            
        }

        /// <summary>
        /// Inits client.
        /// If sConn setting is true -> serial client
        /// Else -> TCPClient
        /// Connects ConnectionStatusChangedHandler
        /// </summary>
        private void initClient()
        {
            if (Convert.ToBoolean((string)Settings.get("sConn")))
            {                
                c = new SerialClient((string)Settings.get("sPort"));
            }
            else
            {
                c = new TCPClient((string)Settings.get("ip"), Convert.ToInt32((string)Settings.get("port")), (string)Settings.get("password"));
            }
            c.csc += new ConnectionStatusChangedHandler(connectionStatusChanged);
        }

        /// <summary>
        /// If vibrate setting is enabled function vibrates for 50ms.
        /// </summary>
        private void vibrate()
        {
            try
            {
                if (Convert.ToBoolean((string)Settings.get("vibrate")))
                {
                    SetVibrate(true);
                    Thread.Sleep(50);
                    SetVibrate(false);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //connect / disconnect
        /// <summary>
        /// Method connected with Connect menu item.
        /// Connects / disconnect to / from server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            if (c.isConnected())
            {
                c.disconnect();
            }
            else
            {
                try
                {
                    c.connect();
                }

                catch (TimeoutException)
                {
                    MessageBox.Show("Timed out. Server is not responding.");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Wrong Password")
                    {
                        MessageBox.Show("Wrong Password!");
                    }
                    else
                    {
                        MessageBox.Show("Connection Error");
                    }
                }
            }
        }
     
        /// <summary>
        /// Function connected with ConnectionStatusChangedHandler.
        /// Updates interface text's (Connected / Disconnected).
        /// </summary>
        /// <param name="status">True -> connected, False -> disconnected</param>
        public void connectionStatusChanged(bool status)
        {
            if (status)
            {
                menuItemConnect.Text = "Disconnect";
            }
            else
            {
                menuItemConnect.Text = "Connect";
            }
        }        

        /// <summary>
        /// Wrapped client function.
        /// Sends data to server.
        /// Catches exception thrown by client class.
        /// </summary>
        /// <param name="str">Data to send.</param>
        private void send(string str)
        {
            try
            {
                c.send(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Server error. Disconnecting.");
                c.disconnect();
            }
        }

        /// <summary>
        /// Mouse button press action.
        /// Creates SMouseTab object.
        /// Connects send and vibrate handlers.
        /// Shows module window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressButton1_Click(object sender, EventArgs e)
        {
            SMouseTab t = new SMouseTab();
            t.send = new sendFunction(send);
            t.vibrate = new vibrateFunction(vibrate);
            showModuleWindow(t);
        }

        /// <summary>
        /// Media button press action.
        /// Creates MediaTab object.
        /// Connects send handler.
        /// Shows module window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressButton2_Click(object sender, EventArgs e)
        {
            MediaTab t = new MediaTab();
            t.send = new sendFunction(send);
            showModuleWindow(t);
        }
                                
        /// <summary>
        /// Utils button press action.
        /// Creates UtilsTab object.
        /// Connects send handler.
        /// Shows module window.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressButton3_Click(object sender, EventArgs e)
        {
            UtilsTab t = new UtilsTab();
            t.send = new sendFunction(send);
            showModuleWindow(t);
        }

        /// <summary>
        /// TouchPad button press action.
        /// Creates TouchPadTab object.
        /// Connects send handler.
        /// Shows module window.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressButton4_Click(object sender, EventArgs e)
        {
            TouchPadTab t = new TouchPadTab();
            t.send = new sendFunction(send);
            showModuleWindow(t);
        }

        /// <summary>
        /// Function creating ModuleWindow object.
        /// Sets main control by setModule function.
        /// Shows window.
        /// </summary>
        /// <param name="uc">User control which will be set as main widget in ModuleWindow.</param>
        private void showModuleWindow(UserControl uc)
        {
            ModuleWindow mw = new ModuleWindow();            
            mw.setModule(uc);
            mw.Show();
            mw.Focus();
        }

        /// <summary>
        /// Menu item settings action.
        /// Disconnects from server if connected.
        /// Shows settings window.
        /// After closing settings window initsClient again checking settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            if (c != null && c.isConnected())
            {
                menuItemConnect_Click(null, null); //rozlaczanie i aktualizacja textow
            }

            (new SettingsForm()).ShowDialog();
            try
            {
                initClient();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong settings");
                menuItemSettings_Click(null, null);
            }
        }

        /// <summary>
        /// Shows about window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            AboutWindow aw = new AboutWindow();
            aw.Show();
        }

    }
}