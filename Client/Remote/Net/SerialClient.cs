using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace Remote
{
    /// <summary>
    /// Class providing serial port support.
    /// </summary>
    class SerialClient: Client
    {
        SerialPort sp = new SerialPort();

        /// <summary>
        /// Sets Serial Port parameters (the same as in server) except port name.
        /// You have to add outgoing port in bluetooth settings before opening port.
        /// </summary>
        /// <param name="port">Serial port name.</param>
        public SerialClient(string port)
        {            
            sp.PortName = port;
            sp.BaudRate = 9600;
            sp.Parity = Parity.Even;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.XOnXOff;

            sp.ReadTimeout = 5000;
            sp.WriteTimeout = 1000;
        }

        /// <summary>
        /// Opens serial port and if succeeded calls connect() of parent class.
        /// </summary>
        public override void connect()
        {
            try
            {             
                sp.Open();
            }
            catch
            {
                throw new Exception();
            }

            if (sp.IsOpen)
            {
                base.connect();
            }
        }

        /// <summary>
        /// Closes port and calls disconnect from parent class.
        /// </summary>
        public override void disconnect()
        {            
            sp.Close();
            base.disconnect();
        }

        /// <summary>
        /// Sends string over serial port.
        /// </summary>
        /// <param name="str">String to send.</param>
        public override void send(string str)
        {
            if (sp.IsOpen)
            {
                sp.WriteLine(str);
            }
        }

        /// <summary>
        /// Gets string from serial port.
        /// </summary>
        /// <returns>Received string or "" if serial port is not opened.</returns>
        public override string get()
        {            
            if (sp.IsOpen)
            {
                return sp.ReadLine();
            }
            return "";                   
        }
        
        /// <summary>
        /// All available serial ports.
        /// </summary>
        /// <returns>Array of strings - available serial ports.</returns>
        public static string[] getPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
