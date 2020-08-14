using System;
using System.Collections.Generic;
using System.Linq;
using Neural_Network_and_AI;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork NeuralNetwork = new NeuralNetwork(new Topology(0.1, 4, 1, 5));

            double[][] Dataset =
            {
                new double[] {0, 0, 0, 0},
                new double[] {0, 0, 0, 1},
                new double[] {0, 0, 1, 0},
                new double[] {0, 0, 1, 1},
                new double[] {0, 1, 0, 0},
                new double[] {0, 1, 0, 1},
                new double[] {0, 1, 1, 0},
                new double[] {0, 1, 1, 1},
                new double[] {1, 0, 0, 0},
                new double[] {1, 0, 1, 0},
                new double[] {1, 0, 1, 1},
                new double[] {1, 1, 0, 0},
                new double[] {1, 1, 0, 1},
                new double[] {1, 1, 1, 0},
                new double[] {1, 1, 1, 1}
            };

            double[] Expected = 
            {
                0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1
            };

            Console.WriteLine(NeuralNetwork.LearnNetwork(Dataset, Expected, 2000));
            Console.WriteLine(NeuralNetwork.PushSignalsThroughNetwork(new double[] { 1, 0, 0, 1}).Max());
        }
    }
}
