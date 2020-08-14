using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        internal double[] _Weights { get; set; }

        internal NeuronType _NeuronType { get; set; }

        internal double[] _Inputs { get; set; }

        internal double _Output { get; set; }

        internal double _Delta { get; set; }

        internal delegate double ActivationFunction(double x);

        internal delegate double ActivationFunctionDerivative(double x);

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

            //_Inputs = Inputs.ToArray() ?? throw new ArgumentNullException(nameof(Inputs));

            for (int i = 0; i < InputsCount; ++i)
            {
                _Weights[i] = 1;
            }
        }

        /// <summary>
        /// A function for neuron which sums the inputs multiplied by corresponding weight and functioned by ActivationFunction
        /// </summary>
        /// <param name="Inputs">The collection of input signals</param>
        /// <returns></returns>
        internal double FeedForward(IEnumerable<double> Inputs, ActivationFunction ActivationFunction)
        {
            double Sum = 0;
            _Inputs = Inputs.ToArray() ?? throw new ArgumentNullException(nameof(Inputs));

            for (int i = 0; i < Inputs.Count(); ++i)
            {
                Sum += _Weights[i] * Inputs.ElementAt(i);
            }

            _Output = _NeuronType != NeuronType.Input ? ActivationFunction(Sum) : Sum;
            return _Output;
        }

        public static double SigmoidFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double SigmoidFunctionDerivative(double x)
        {
            var Sigmoid = SigmoidFunction(x);
            return Sigmoid / (1 - Sigmoid);
        }

        internal void SetNewWeights(double Error, double LearningRate)
        {
            if (_NeuronType == NeuronType.Input) return;

            _Delta = Error * SigmoidFunctionDerivative(_Output);

            double Input;
            for (int i = 0; i < _Weights.Length; ++i)
            {
                Input = _Inputs[i];

                _Weights[i] -= Input * _Delta * LearningRate;
            }
        }
    }
}
