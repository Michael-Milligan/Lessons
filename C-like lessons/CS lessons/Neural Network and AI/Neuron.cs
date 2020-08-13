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
        public double[] _Weights { get; set; }

        public NeuronType _NeuronType { get; set; }

        public double _Output { get; set; }

        /// <summary>
        /// Initialises the new neuron with all weights equal to 1
        /// </summary>
        /// <param name="InputsCount"></param>
        /// <param name="NeuronType"></param>
        public Neuron(int InputsCount, NeuronType NeuronType = NeuronType.Hidden)
        {
            if (InputsCount == 0) throw new ArgumentNullException("InputsCount");
            _NeuronType = NeuronType;
            _Weights = new double[InputsCount];

            for (int i = 0; i < InputsCount; ++i)
            {
                _Weights[i] = 1;
            }
        }

        /// <summary>
        /// An activation function for neuron which sums the inputs multiplied by corresponding weight
        /// </summary>
        /// <param name="Inputs">The collection of input signals</param>
        /// <returns></returns>
        public double FeedForward(IEnumerable<double> Inputs)
        {
            double Sum = 0;
            
            for (int i = 0; i < Inputs.Count(); ++i)
            {
                Sum += _Weights[i] * Inputs.ElementAt(i);
            }

            _Output = SigmoidFunction(Sum);
            return _Output;
        }

        public static double SigmoidFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
