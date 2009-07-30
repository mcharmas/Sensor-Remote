using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    /// <summary>
    /// Function used for received data processing.
    /// </summary>
    /// <param name="str">String to parse.</param>
    delegate void DataHandler(String str);

    /// <summary>
    /// Function used for connection status change handling.
    /// </summary>
    /// <param name="status">client connected / disconnected</param>
    delegate void ClientConnectionChanged(bool status);

    /// <summary>
    /// Function used for server status change handling.
    /// </summary>
    /// <param name="status">server up / down</param>
    delegate void ServerStatusChanged(bool status);

    abstract class Server
    {
        /// <summary>
        /// Data handler object needed to connect delegate DataProcess.
        /// </summary>
        protected DataHandler dh;

        /// <summary>
        /// Function called when client connects / disconnects
        /// </summary>
        public ClientConnectionChanged cc = null;
        
        /// <summary>
        /// Function called when server started / stopped.
        /// </summary>
        public ServerStatusChanged svc = null;

        protected bool clientConnected = false;
        protected bool listening = false;

        /// <summary>
        /// Delegated function used to process data.
        /// </summary>
        private DataProcess dp = null;
        /// <summary>
        /// Function used to sent data.
        /// </summary>
        /// <param name="str">Input string.</param>
        abstract protected void send(string str);     

        /// <summary>
        /// Starts data processor.
        /// </summary>
        virtual public void start()
        {
            dp = new DataProcess();
            dh += new DataHandler(dp.process);
            dp.start();
        }

        /// <summary>
        /// Stops data processor.
        /// </summary>
        virtual public void stop()
        {
            dp.stop();
            dh -= new DataHandler(dp.process);
            dp = null;
        }
        
        /// <summary>
        /// Authenticates connection.
        /// </summary>
        /// <param name="password">password</param>
        /// <returns>if password is ok</returns>
        protected bool auth(string password)
        {
            Console.WriteLine("Authenticating...");
            if (password != Properties.Settings.Default.password)
            {
                send("WP;");
                return false;
            }

            send("OK;");
            return true;
        }

        /// <summary>
        /// Function called when connection status has changed.
        /// It calls ClientConnectionChanged handler as well.
        /// </summary>
        /// <param name="stat">connected / disconnected</param>
        protected void connectionStatusChanged(bool stat)
        {
            clientConnected = stat;
            if (cc != null)
            {
                cc(stat);
            }
        }

        /// <summary>
        /// Function called to stop/start server or when server is stopped / started.
        /// It calls ServerStatusChanged handler as well.
        /// Sets listening value to false (causes SerialServer thread to stop).
        /// </summary>
        /// <param name="stat">up / down</param>
        protected void serverStatusChanged(bool stat)
        {
            listening = stat;
            if (svc != null)
            {
                svc(stat);
            }
        }

        /// <summary>
        /// Indicated wheather server is up or down.
        /// </summary>
        /// <returns>server status</returns>
        public bool isRunning()
        {
            return listening;
        }

        /// <summary>
        /// Indicates if client is connected.
        /// </summary>
        /// <returns>if client connected</returns>
        public bool hasClient()
        {
            return clientConnected;
        }
    }
}
