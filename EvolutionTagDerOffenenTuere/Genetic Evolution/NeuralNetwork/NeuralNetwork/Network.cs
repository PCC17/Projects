using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Network
    {
        public InputNodeLayer inputNodeLayer;
        public OutputNodeLayer outputNodeLayer;

        static Random rnd = new Random();

        public Network(int inputNodesCount, int outputNodesCount)
        {
            outputNodeLayer = new OutputNodeLayer(outputNodesCount);
            inputNodeLayer = new InputNodeLayer(inputNodesCount, outputNodeLayer);
        }

        public List<double> GetResult(List<double> inputs)
        {
            inputNodeLayer.AddInputs(inputs);
            inputNodeLayer.PushOutputs();
            return outputNodeLayer.GetOutputs();
        }

        public static Network CompineNetwork(Network n1, Network n2)
        {
            if (n1.inputNodeLayer.NodeCount() == n2.inputNodeLayer.NodeCount() &&
                n1.outputNodeLayer.NodeCount() == n2.outputNodeLayer.NodeCount())
            {
                List<double> allWeights1 = n1.inputNodeLayer.GetAllWeights();
                List<double> allWeights2 = n2.inputNodeLayer.GetAllWeights();

                int split = rnd.Next(0, allWeights1.Count);
                for (int i = split; i < allWeights1.Count; i++)
                {
                    allWeights2[i] = allWeights1[i];
                }

                Network n = new Network(n1.inputNodeLayer.NodeCount(), n1.outputNodeLayer.NodeCount());
                n.inputNodeLayer.SetWeights(allWeights2.ToArray());
                return n;
            }
            return null;
        }
    }
}
