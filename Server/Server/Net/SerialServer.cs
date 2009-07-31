using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// Call implementing abstract Server class.
    /// Used for serial port connection.
    /// Before opening a port you have to add "New incoming port." in bluetooth settings.    
    /// </summary>
    class SerialServer: Server
    {        
        SerialPort sp = new SerialPort();
        Thread readThread;
     
        /// <summary>
        /// Sets connection parametes:
        /// BaudRade: 9600
        /// Parity: Even
        /// DataBits: 8
        /// StopBits: One
        /// Handshake: XOnXOff
        /// And port name as param.
        /// </summary>
        /// <param name="port">Serial port name to be opened.</param>
        public SerialServer(string port)
        {
            sp.PortName = port;            
            sp.BaudRate = 9600;
            sp.Parity = Parity.Even;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.XOnXOff;
        }

        /// <summary>
        /// Threaded function waiting for data from serial port and passing it to data handler.
        /// Switching listening param to false ends thread.
        /// No authentication in serial connection (not needed?).
        /// No indication if client connected, thats why "No client connected" 
        /// is always visible in interface during serial connection.
        /// </summary>
        public void handleCommunication()
        {            
            while (listening)
            {
                try
                {
                    string line = sp.ReadLine();
                    //Console.WriteLine(line);

                    if (dh != null)
                    {
                        dh(line);
                    }
                }
                catch { }
            }            
        }

        /// <summary>
        /// Overrided function openning port, starting listening thread
        /// </summary>
        public override void start()
        {
            base.start();

            try
            {                               
                readThread = new Thread(new ThreadStart(handleCommunication));
                sp.Open();                
                readThread.Start();
                serverStatusChanged(true);
            }
            catch
            {
                MessageBox.Show("Can't start serial server.");
            }

        }

        /// <summary>
        /// Stops listening thread and closes serial port.
        /// </summary>
        public override void stop()
        {
            base.stop();

            serverStatusChanged(false);

            try
            {
                sp.Close();
            }
            catch { }
            //readThread.Abort();
        }

        /// <summary>
        /// Sends data over serial. Not used but working.
        /// </summary>
        /// <param name="str">Data to be send.</param>
        protected override void send(string str)
        {
            try
            {
                sp.WriteLine(str);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Returns available ports.
        /// </summary>
        /// <returns>Available port names.</returns>
        public static string[] getPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
