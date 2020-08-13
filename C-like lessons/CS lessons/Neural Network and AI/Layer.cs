using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural_Network_and_AI
{
    class Layer
    {
        public Neuron[] _Neurons { get; set; }

        /// <summary>
        /// Initializes a new layer after check whether all of neurons are of specified type
        /// </summary>
        /// <param name="Neurons">Collection of the neurons to copy</param>
        /// <param name="NeuronType">The type of the neurons in collection</param>
        public Layer(IEnumerable<Neuron> Neurons, NeuronType NeuronType)
        {
            if (Neurons == null || Neurons.Count() == 0) throw new ArgumentNullException("Neurons");
            if (Neurons.Select(item => item._NeuronType).Any(item => item != NeuronType)) throw new ArgumentException("Not all neurons are of a specified type");
            _Neurons = Neurons.ToArray();
        }
    }
}
