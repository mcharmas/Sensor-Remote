using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;


namespace Remote
{
    delegate void ConnectionStatusChangedHandler(bool status);
    /// <summary>
    /// Class used for base of communication with server on TCP/IP layer.
    /// </summary>
    abstract class Client
    {
        public ConnectionStatusChangedHandler csc = null;
        protected string password;
        protected bool connected = false;

        /// <summary>
        /// Authorizing function.
        /// </summary>
        /// <returns>If authorization by server was successful.</returns>
        public bool auth()
        {
            try
            {
                connected = true;
                send(password);
                if (get() == "WP;")
                {
                    disconnect();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Sets connect status to true.
        /// Executes ConnectionStatusChange handler.
        /// </summary>
        virtual public void connect()
        {
            connected = true;
            if (csc != null)
            {
                csc(true);
            }
        }

        /// <summary>
        /// Sets connected status to false.
        /// Executes ConnectionStatusChange handler.
        /// </summary>
        virtual public void disconnect()
        {
            if (csc != null)
            {
                csc(false);
            }
            connected = false;
        }

        /// <summary>
        /// Returns if is connected to server.
        /// </summary>
        /// <returns>connection status</returns>
        public bool isConnected()
        {
            return connected;
        }

        /// <summary>
        /// Abstract class used to send data.
        /// </summary>
        /// <param name="str">Strign to send.</param>
        abstract public void send(string str);
        
        /// <summary>
        /// Abstract class used to receive data.
        /// </summary>
        /// <returns>Received string.</returns>
        abstract public string get();
    }



}
