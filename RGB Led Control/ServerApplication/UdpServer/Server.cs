using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerArduinoCommunication
{
     public delegate void HandleBytes(byte[] array);


    public class Server
    {


        private IPAddress ipAddress = IPAddress.Any;
        private int serverPort = 51512;
        private int msgLength = 3;
        
        public HandleBytes hB;
        private Thread serverThread;

        public Server(int serverPort, int msgLength)
        {
            serverThread = new Thread(ServerThread);
            this.serverPort = serverPort;
            this.msgLength = msgLength;
        }

        public void StartServer()
        {
            if (serverThread.ThreadState != ThreadState.Running)
                serverThread.Start();
        }

        public void StopServer()
        {
            if (serverThread.ThreadState == ThreadState.Running)
                serverThread.Abort();
        }

        private void ServerThread()
        {

            UdpClient server = new UdpClient(new IPEndPoint(IPAddress.Any, serverPort));
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] msg = server.Receive(ref sender);
                    if (msg.Length == msgLength)
                    {
                 
                        hB(msg);
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                }
            }
        }


    }
}
