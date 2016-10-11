using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort sp = new SerialPort(Console.ReadLine());
            sp.Open();
            while (true)
            {
                byte a = Convert.ToByte(Console.ReadLine());
                byte b = Convert.ToByte(Console.ReadLine());
                byte c = Convert.ToByte(Console.ReadLine());
                sp.Write(new byte[] { a, b, c }, 0, 3);

            }
        }
    }
}
