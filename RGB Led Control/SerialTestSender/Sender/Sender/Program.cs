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
            //while (true)
            //{
            //    byte a = Convert.ToByte(Console.ReadLine());
            //    byte b = Convert.ToByte(Console.ReadLine());
            //    byte c = Convert.ToByte(Console.ReadLine());
            //    sp.Write(new byte[] { a, b, c }, 0, 3);

            //}
            while (true)
            {
                for (int i = 0; i < 256; i++)
                {
                    sp.Write(new byte[] {(byte) i, (byte) (255 - i), 0}, 0, 3);
                    System.Threading.Thread.Sleep(20);
                }
                for (int i = 0; i < 256; i++)
                {
                    sp.Write(new byte[] {(byte) (255 - i), (byte) i, 0}, 0, 3);
                    System.Threading.Thread.Sleep(20);
                }
                for (int i = 0; i < 256; i++)
                {
                    sp.Write(new byte[] { 0, (byte)(255 - i), (byte) i }, 0, 3);
                    System.Threading.Thread.Sleep(20);
                }
                for (int i = 0; i < 256; i++)
                {
                    sp.Write(new byte[] { (byte)i, 0, (byte)(255 - i) }, 0, 3);
                    System.Threading.Thread.Sleep(20);
                }
                for (int i = 0; i < 256; i++)
                {
                    sp.Write(new byte[] { (byte)(255 - i), (byte)i,0 }, 0, 3);
                    System.Threading.Thread.Sleep(20);
                }
            }
        }
    }
}
