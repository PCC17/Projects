using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class InputNodeLayer
    {
        List<InputNode> nodes;

        public InputNodeLayer(int amount, OutputNodeLayer outputNodeLayer)
        {
            nodes = new List<InputNode>();
            for (int i = 0; i < amount; i++)
            {
                nodes.Add(new InputNode( outputNodeLayer.GetNodes()));
            }
        }

        public void PushOutputs()
        {
            foreach (InputNode n in nodes)
            {
                n.PushOutputs();
                n.Reset();
            }
        }

        public void AddInputs(List<double> inputs)
        {
            if (inputs.Count == nodes.Count)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    nodes[i].AddInput(inputs[i]);
                }
            }
        }

        public List<double> GetAllWeights()
        {
            List<double> list = new List<double>();
            foreach (InputNode n in nodes)
            {
                foreach (double d in n.GetWeights())
                {
                    list.Add(d);
                }
            }
            return list;
        }

        public void SetWeights(double[] array)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].ConnectionsCount(); j++)
                {
                    int u = i*(nodes[i].ConnectionsCount() - 1) + j;
                    nodes[i].SetWeightOfNode(j, array[u]);
                }
            }
        }

        public int NodeCount()
        {
            return nodes.Count;
        }
    }
    class OutputNodeLayer
    {
        private List<Node> nodes;

        public OutputNodeLayer(int amount)
        {
            nodes = new List<Node>();
            for (int i = 0; i < amount; i++)
            {
                nodes.Add(new Node());
            }
        }

        public double? GetOutput(int index)
        {
            if (index >= 0 && index < nodes.Count)
                return nodes[index].GetOutput();
            return null;
        }

        public List<double> GetOutputs()
        {
            List<double> list = new List<double>();
            foreach (Node n in nodes)
            {
                list.Add(n.GetOutput());
                n.Reset();
            }
            return list;
        }

        internal List<Node> GetNodes()
        {
            return nodes;
        }
        public int NodeCount()
        {
            return nodes.Count;
        }
    }
}
