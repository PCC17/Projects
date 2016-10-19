using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Network n = new Network(10, 4);
            double d1 = Convert.ToDouble(Console.ReadLine());
            double d2 = Convert.ToDouble(Console.ReadLine());
            foreach (double d in n.GetResult(new List<double>() { d1, d2 }))
            {
                Console.WriteLine(d);
            }

            Network n2 = new Network(10, 4);
            d1 = Convert.ToDouble(Console.ReadLine());
            d2 = Convert.ToDouble(Console.ReadLine());
            foreach (double d in n2.GetResult(new List<double>() { d1, d2 }))
            {
                Console.WriteLine(d);
            }

            Network n3 = Network.CompineNetwork(n, n2);
            d1 = Convert.ToDouble(Console.ReadLine());
            d2 = Convert.ToDouble(Console.ReadLine());
            foreach (double d in n3.GetResult(new List<double>() { d1, d2 }))
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();

        }
    }
}
