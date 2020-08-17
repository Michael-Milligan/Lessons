using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neural_Network_and_AI
{
    [Serializable]
    public class NeuralNetwork
    {
        internal List<Layer> _Layers { get; set; }

        internal Topology _Topology { get; set; }

        public double _StandardError { get; set; }

        public NeuralNetwork(Topology Topology)
        {
            _Topology = Topology;
            _Layers = new List<Layer>();

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();

            RandomlySetWeights();
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
        public IEnumerable<double> PushSignalsThroughNetwork(IEnumerable<double> InputSignals)
        {
            SendSignalsToInput(InputSignals.ToArray());

            Layer CurrentLayer;
            double[] PreviousSignals;
            for (int i = 1; i < _Layers.Count; ++i)
            {
                CurrentLayer = _Layers[i];
                PreviousSignals = _Layers[i - 1].GetOutputs();

                foreach (var Neuron in CurrentLayer._Neurons)
                {
                    Neuron.FeedForward(PreviousSignals, Neuron.SigmoidFunction);
                }
            }

            return _Layers.Last().GetOutputs();
        }

        private void SendSignalsToInput(double[] InputSignals)
        {
            double CurrentSignal;
            for (int i = 0; i < InputSignals.Length; ++i)
            {
                CurrentSignal = InputSignals[i];

                _Layers[0]._Neurons[i].FeedForward(new double[] { CurrentSignal }, Neuron.SigmoidFunction);
            }
        }

        internal void RandomlySetWeights()
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
                        _Layers[i]._Neurons[j]._Weights[k] = random.NextDouble() * 2 - 1;
                    }
                }
            }
        }

        public double TrainNetwork(double[][] Dataset, double[] Expected, int Epochs)
        {
            if (Dataset.GetLength(0) != Expected.Length) throw new ArgumentException("The inputs don't have the same lengthes");
            double Result = 0.0;
            for (int i = 0; i < Epochs; ++i)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Current epoch: {i + 1}                                       ");
                for (int j = 0; j < Dataset.GetLength(0); ++j)
                {
                    Result += BackPropagation(Expected[j], Dataset[j]);
                }
            }
            _StandardError = Result / Epochs;
            return _StandardError;
        }

        /// <summary>
        /// Gets the biggest actual result from the network and makes the BackPropagation algorithms
        /// </summary>
        /// <param name="Expected"></param>
        /// <param name="Inputs"></param>
        internal double BackPropagation(double Expected, IEnumerable<double> Inputs)
        {
            var ActualResult = PushSignalsThroughNetwork(Inputs).Max();

            var OutputError = ActualResult - Expected;

            foreach (var Neuron in _Layers.Last()._Neurons)
            {
                Neuron.SetNewWeights(OutputError, _Topology._LearningRate);
            }

            for (int i = _Layers.Count - 2; i >= 0; --i)
            {
                var Layer = _Layers[i];
                var PreviousLayer = _Layers[i + 1];
                Neuron PreviousNeuron;

                for (int j = 0; j < Layer._Neurons.Length; ++j)
                {
                    for (int k = 0; k < PreviousLayer._Neurons.Length; ++k)
                    {
                        PreviousNeuron = PreviousLayer._Neurons[k];
                        var Error = PreviousNeuron._Weights[j] * PreviousNeuron._Delta;
                        Layer._Neurons[j].SetNewWeights(Error, _Topology._LearningRate);
                    }
                }
            }
            return OutputError * OutputError;
        }

        /// <summary>
        /// Trains the network with the Backpropagation method
        /// </summary>
        /// <param name="Dataset"></param>
        /// <param name="Expected"></param>
        /// <param name="Epochs">The number which defines the period of training</param>
        /// <param name="StandardError"></param>
        public void TrainWhileStandardErrorMoreThan(double[][] Dataset, double[] Expected, int Epochs, double StandardError)
        {
            File.WriteAllText("PreviousError.txt", TrainNetwork(Dataset, Expected, Epochs).ToString());
            do
            {
                NeuralNetwork CopiedNetwork;
                Methods.CopyNetwork(this, out CopiedNetwork);

                var CurrentError = TrainNetwork(Dataset, Expected, Epochs);
                if (_StandardError < Convert.ToDouble(File.ReadAllLines("PreviousError.txt")[0]))
                {
                    Methods.SerializeNetwork(this, "1.dat");
                    File.WriteAllText("PreviousError.txt", _StandardError.ToString());
                }
                if (CopiedNetwork._StandardError <= _StandardError)
                {
                    CopiedNetwork._Layers = _Layers;
                    CopiedNetwork._StandardError = _StandardError;
                    continue;
                }
                Console.WriteLine(CurrentError);
            }
            while (this._StandardError > StandardError);
        }
    }
}
