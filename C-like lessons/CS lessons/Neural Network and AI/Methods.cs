using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic.CompilerServices;

namespace Neural_Network_and_AI
{
    public class Methods
    {
        public static void SerializeNetwork(NeuralNetwork NeuralNetwork, string Path)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream(Path, FileMode.Create))
            {
                Formatter = new BinaryFormatter();
                Formatter.Serialize(Stream, NeuralNetwork);
            }
        }

        public static void DeserializeNetwork(out NeuralNetwork NeuralNetwork, string Path)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream(Path, FileMode.Open))
            {
                Formatter = new BinaryFormatter();
                NeuralNetwork = Formatter.Deserialize(Stream) as NeuralNetwork;
            }
        }

        public static Tuple<double[], double[][]> ReadCSV(string Path)
        {
            string[] Strings = File.ReadAllLines(Path);
            string[][] Data = new string[Strings.Length][];
            for (int i = 0; i < Data.GetLength(0); ++i)
            {
                Data[i] = Strings[i].Split(',');
            }

            double[][] Dataset = new double[Strings.Length][];
            double[] Expected = new double[Strings.Length];

            for (int i = 0; i < Dataset.Length; ++i)
            {
                Dataset[i] = Data[i][..^1].Select(item => Convert.ToDouble(item)).ToArray();
                Expected[i] = Convert.ToDouble(Data[i][^1]);
            }
            return new Tuple<double[], double[][]>(Expected, Dataset);
        }

        public static void CopyNetwork(NeuralNetwork ToCopy,out NeuralNetwork CopyTo)
        {
            SerializeNetwork(ToCopy, "2.dat");
            NeuralNetwork CopiedNetwork;
            DeserializeNetwork(out CopiedNetwork, "2.dat");
            CopyTo = CopiedNetwork;
        }
    }
}
