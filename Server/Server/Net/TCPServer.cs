using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;

namespace Server
{
    class TCPServer: Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        
        TcpClient tcpClient = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="IP">listening ip - when empty all interfaces</param>
        /// <param name="port">listening port</param>
        public TCPServer(string IP, int port)
        {
            IPAddress ip;
            if (IP == "")
                ip = IPAddress.Any;
            else
                ip = IPAddress.Parse(IP);

            this.tcpListener = new TcpListener(ip, port);
        }

        /// <summary>
        /// Starts TCP server.
        /// </summary>
        public override void start()
        {
            base.start();
            serverStatusChanged(true);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        /// <summary>
        /// Stops server.
        /// </summary>
        public override void stop()
        {
            serverStatusChanged(false);

            if (tcpClient != null)
                tcpClient.Close();

            tcpListener.Stop();
            listenThread.Abort();            
            base.stop();
        }

        /// <summary>
        /// Sends data to client.
        /// </summary>
        /// <param name="str">String to send.</param>
        protected override void send(string str)
        {
            if (clientConnected)
            {
                try
                {
                    //Console.WriteLine("Sending: " + str);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    tcpClient.GetStream().Write(ba, 0, ba.Length);
                }
                catch (Exception)
                {
                    disconnect();
                    throw new Exception("SEND_ERROR");
                }
            }
        }

        /// <summary>
        /// Functions working in listening thread. Starts tcpListener and waits for user to connect.
        /// Then calls HandleClientComm (in the same thread).
        /// One client can be connected at the same time.
        /// </summary>
        private void ListenForClients()
        {
            try
            {
                this.tcpListener.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Port busy!");
            }


            while (true)
            {
                try
                {
                    TcpClient client = this.tcpListener.AcceptTcpClient();
                    //System.Diagnostics.Debug.WriteLine("Client CONNECTED");
                    HandleClientComm(client);
                }
                catch (Exception)
                {

                    //MessageBox.Show(ex.ToString());

                }
            }
        }

        /// <summary>
        /// Handles client communication. Performs authentication after client connected and waits
        /// for data passing it to DataHandler. Performs cleanup after client disconnected.
        /// </summary>
        /// <param name="client"></param>
        private void HandleClientComm(object client)
        {
            tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            connectionStatusChanged(true);            
            byte[] message = new byte[4096];
            int bytesRead;
            bool authentication = true;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine(encoder.GetString(message, 0, bytesRead));

                if (authentication)
                {
                    if (!auth(encoder.GetString(message, 0, bytesRead)))
                    {
                        break;
                    }
                    else
                    {
                        authentication = false;
                    }
                }

                if (dh != null)
                {
                    dh(encoder.GetString(message, 0, bytesRead));
                }
            }
            disconnect();
        }

        /// <summary>
        /// Disconnects client from server.
        /// </summary>
        public void disconnect()
        {
            connectionStatusChanged(false);
            tcpClient.Close();
            tcpClient = null;
            //System.Diagnostics.Debug.WriteLine("Client DISCONNECTED");
        }
    }
}

