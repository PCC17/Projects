using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Connection
    {
        private int MinWeight = -99;
        private int MaxWeight = 100;
        private static Random rnd = new Random();

        private Node targetNode;
        public double Weight { get; set; }

        public Connection(Node targetNode, double weight)
        {
            this.targetNode = targetNode;
            this.Weight = weight;
        }

        public Connection(Node targetNode)
        {
            this.targetNode = targetNode;
            double d = (double)(rnd.Next(MinWeight, MaxWeight)) / 100;
            Weight = d;
        }
        public void SendInputToTargetNode(double d)
        {
            targetNode.AddInput(Weight * d);
        }

    }
}
