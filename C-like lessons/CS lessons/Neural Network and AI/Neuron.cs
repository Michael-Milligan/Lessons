using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_and_AI
{
    public enum NeuronType
    {
        Input,
        Hidden,
        Output
    }

    public class Neuron
    {
        public List<double> _Weights { get; set; }

        public NeuronType _NeuronType { get; set; }

        public double _Output { get; set; }

        public Neuron(int InputsCount, NeuronType NeuronType = NeuronType.Hidden)
        {
            if (InputsCount == 0) throw new ArgumentNullException("InputsCount");
            _NeuronType = NeuronType;
            _Weights = new List<double>();

            for (int i = 0; i < InputsCount; ++i)
            {
                _Weights.Add(1);
            }
        }

        public double FeedForward(IEnumerable<double> Inputs)
        {
            double Sum = 0;
            
            for (int i = 0; i < Inputs.Count(); ++i)
            {
                Sum += _Weights[i] * Inputs.ElementAt(i);
            }

            _Output = Sigmoid(Sum);
            return _Output;
        }

        public static double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
