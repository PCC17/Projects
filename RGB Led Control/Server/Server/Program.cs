using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int SERVER_PORT = 51512;
        const int MSG_LENGTH = 3;
        static SerialPort arduino;


        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Ticks);
            Console.Write("Serieller Port: ");
            string port = Console.ReadLine();
            Console.Write("Baudrate: ");
            int baudrate = Convert.ToInt32(Console.ReadLine());


            UdpClient server = new UdpClient(new IPEndPoint(IPAddress.Any, SERVER_PORT));
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            arduino = new SerialPort(port, baudrate);
           arduino.Open();

            while (true)
            {
                try
                {
                    byte[] msg = server.Receive(ref sender);
                    if (msg.Length == MSG_LENGTH)
                    {
                        foreach (var v in msg)
                        {
                            Console.WriteLine(v);
                        }
                      arduino.Write(msg, 0, msg.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Thread.Sleep(10);
            }
        }
    }
}