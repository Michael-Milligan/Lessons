using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Neural_Network_and_AI;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork NeuralNetwork
                = new NeuralNetwork(new Topology(0.0001, 13, 1, 16));
            //Methods.DeserializeNetwork(out NeuralNetwork);

            
            var Data = Methods.ReadCSV("heart.csv");

            NeuralNetwork.TrainWhileStandardErrorMoreThan(Data.Item2, Data.Item1, 2000,  0.0001);



            //Console.WriteLine(NeuralNetwork.PushSignalsThroughNetwork(new double[] { 1, 0, 0, 1}).Max());
        }
    }
}
