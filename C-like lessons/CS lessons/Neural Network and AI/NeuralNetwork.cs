using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_and_AI
{
    public class NeuralNetwork
    {
        public List<Layer> _Layers { get; set; }

        public Topology _Topology { get; set; }

        public NeuralNetwork(Topology Topology)
        {
            _Topology = Topology;
            _Layers = new List<Layer>();

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();


        }

        /// <summary>
        /// Creates an OutputLayer from new neurons whose quantity is written in _Topology
        /// </summary>
        private void CreateOutputLayer()
        {
            var OutputNeurons = new List<Neuron>();
            for (int i = 0; i < _Topology._OutputCount; ++i)
            {
                var Neuron = new Neuron(_Layers.Last().NeuronCount, NeuronType.Output);
                OutputNeurons.Add(Neuron);
            }
            _Layers.Add(new Layer(OutputNeurons, NeuronType.Output));
        }

        /// <summary>
        /// Creates HiddenLayers from new neurons whose quantity is written in _Topology
        /// </summary>
        private void CreateHiddenLayers()
        {
            List<Neuron> HiddenNeurons;
            Neuron Neuron;
            for (int i = 0; i < _Topology._HiddenLayers.Length; ++i)
            {
                HiddenNeurons = new List<Neuron>();
                for (int j = 0; j < _Topology._HiddenLayers[i]; ++j)
                {
                    Neuron = new Neuron(_Layers.Last().NeuronCount, NeuronType.Hidden);
                    HiddenNeurons.Add(Neuron);
                }
                _Layers.Add(new Layer(HiddenNeurons, NeuronType.Hidden));
            }
        }

        /// <summary>
        /// Creates an InputLayer from new neurons whose quantity is written in _Topology
        /// </summary>
        private void CreateInputLayer()
        {
            var InputNeurons = new List<Neuron>();
            for (int i = 0; i < _Topology._InputCount; ++i)
            {
                var Neuron = new Neuron(1, NeuronType.Input);
                InputNeurons.Add(Neuron);
            }
            _Layers.Add(new Layer(InputNeurons, NeuronType.Input));
        }

        /// <summary>
        /// The method that coordinates all methods and classes to get a final result
        /// </summary>
        /// <param name="InputSignals"></param>
        /// <returns></returns>
        private IEnumerable<double> PassSignalsThroughNetwork(double[] InputSignals)
        {
            SendSignalsToInput(InputSignals);

            Layer CurrentLayer;
            double[] PreviousSignals;
            for (int i = 1; i < _Layers.Count; ++i)
            {
                CurrentLayer = _Layers[i];
                PreviousSignals = _Layers[i - 1].GetOutputs();

                foreach (var Neuron in CurrentLayer._Neurons)
                {
                    Neuron.FeedForward(PreviousSignals);
                }
            }

            if (_Topology._OutputCount == 1) return new List<double> { _Layers.Last()._Neurons[0]._Output };
            else return _Layers.Last().GetOutputs();
        }

        private void SendSignalsToInput(double[] InputSignals)
        {
            double CurrentSignal;
            Neuron CurrentNeuron;
            for (int i = 0; i < InputSignals.Length; ++i)
            {
                CurrentSignal = InputSignals[i];
                CurrentNeuron = _Layers[0]._Neurons[i];

                CurrentNeuron.FeedForward(new List<double>());
            }
        }

        public void RandomlySetWeights()
        {
            Random random = new Random();
            var LayersCount = _Layers.Count;
            int NeuronCount, WeightCount;

            for (int i = 0; i < LayersCount; ++i)
            {
                NeuronCount = _Layers[i].NeuronCount;
                for (int j = 0; j < NeuronCount; ++j)
                {
                    WeightCount = _Layers[i]._Neurons[j]._Weights.Length;
                    for (int k = 0; k < WeightCount; ++k)
                    {
                        _Layers[i]._Neurons[j]._Weights[k] = random.NextDouble();
                    }
                }
            }
        }
    }
}
