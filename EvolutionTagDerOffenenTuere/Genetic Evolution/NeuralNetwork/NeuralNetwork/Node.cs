using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Node
    {

        protected double currentInput;

        public Node()
        {
        }
        public virtual double GetOutput()
        {
            return currentInput;
        }

        public void AddInput(double d)
        {
            currentInput += d;
        }

        public void Reset()
        {
            currentInput = 0;
        }
        
    }

    class InputNode : Node
    {
        private List<Connection> connections;

        public InputNode(List<Node> targetNodes)
        {
            connections = new List<Connection>();
            foreach (var tn in targetNodes)
            {

                connections.Add(new Connection(tn));
            }
        }
        public override double GetOutput()
        {
            double d = (1 / (1 + Math.Pow(Math.E, -currentInput)));
            return d;
        }

        public void PushOutputs()
        {
            foreach (Connection c in connections)
            {
                c.SendInputToTargetNode(GetOutput());
            }
        }
        public List<double> GetWeights()
        {
            List<double> d = new List<double>();
            foreach (Connection c in connections)
            {
                d.Add(c.Weight);
            }
            return d;
        }

        public int ConnectionsCount()
        {
            return connections.Count;
        }

        public void SetWeightOfNode(int index, double weight)
        {
            connections[index].Weight = weight;
        }
    }
}
