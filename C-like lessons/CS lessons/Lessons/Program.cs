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
            NeuralNetwork NeuralNetwork;
                //= new NeuralNetwork(new Topology(0.001, 4, 1, 3));
            Methods.DeserializeNetwork(out NeuralNetwork);

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

            //NeuralNetwork.LearnWhileStandardErrorMoreThan(Dataset, Expected, 2000, 0.02);
            

            
            Console.WriteLine(NeuralNetwork.PushSignalsThroughNetwork(new double[] { 1, 1, 1, 1}).Max());
        }
    }
}
