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
    public class ArduinoCommunication
    {
        private SerialPort serialPort;
        public ArduinoCommunication(string port, int baudrate)
        {
           // serialPort = new SerialPort(port, baudrate);
        }

        public void SendData(byte[] bytes)
        {
            //serialPort.Write(bytes, 0, bytes.Length);
        }
    }
}
