using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Remote
{



    /// <summary>
    /// Class providing TCP/IP support.
    /// </summary>
    class TCPClient : Client
    {
        private TcpClient client;
        private IPAddress ip;
        private int port;

        /// <summary>
        /// Creates client object setting all necessary fields.
        /// </summary>
        /// <param name="adr">IP address</param>
        /// <param name="port">port number</param>
        /// <param name="password">server password</param>
        public TCPClient(String adr, int port, string password)
        {
            try
            {
                this.ip = IPAddress.Parse(adr);
                this.port = port;
                this.password = password;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Connects to server with timeout set to 5 sec. Throws TimeoutException when timeout.
        /// After establishing connection function sends password to server. Password i verified.
        /// Throws Exception when password is wrong.
        /// </summary>
        public override void connect()
        {
            try
            {
                client = TimeOutSocket.Connect(new IPEndPoint(this.ip, this.port), 5000);
                if (!auth())
                {
                    disconnect();
                    throw new Exception("Wrong password.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            base.connect();
        }

        /// <summary>
        /// Closes stream and socket.
        /// </summary>
        public override void disconnect()
        {
            if (connected)
            {
                client.GetStream().Close();
                client.Close();
            }
            base.disconnect();
        }

        /// <summary>
        /// Sends string to server. When error - disconnects and throws Exception
        /// </summary>
        /// <param name="str">input string</param>
        public override void send(string str)
        {
            if (isConnected())
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                try
                {
                    client.GetStream().Write(ba, 0, ba.Length);
                }
                catch
                {
                    disconnect();
                    throw new Exception("SEND_ERROR");
                }
            }
        }

        /// <summary>
        /// Gets string from server.
        /// </summary>
        /// <returns>received data</returns>
        public override string get()
        {
            byte[] message = new byte[4096];
            int bytesRead = 0;
            try
            {
                bytesRead = client.GetStream().Read(message, 0, 4096);
            }
            catch
            {
                disconnect();
                throw;
            }

            if (bytesRead == 0)
            {
                disconnect();
            }

            ASCIIEncoding encoder = new ASCIIEncoding();
            return encoder.GetString(message, 0, bytesRead);
        }

    }
}
