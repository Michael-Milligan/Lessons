using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static void CopyNetwork(NeuralNetwork ToCopy, out NeuralNetwork CopyTo)
        {
            SerializeNetwork(ToCopy, "2.dat");
            NeuralNetwork CopiedNetwork;
            DeserializeNetwork(out CopiedNetwork, "2.dat");
            CopyTo = CopiedNetwork;
        }

        public static double[][] ScaleTheData(double[][] Inputs)
        {
            var Result = new double[Inputs.GetLength(0)][];

            for (int column = 0; column < Inputs[0].Length; ++column)
            {
                var Min = Inputs[0][column];
                var Max = Inputs[0][column];
                for (int row = 0; row < Inputs.GetLength(0); ++row)
                {
                    Result[row] = new double[Inputs[0].Length];
                    var Item = Inputs[row][column];
                    if (Min > Item) Min = Item;
                    if (Max < Item) Max = Item;
                }

                var Difference = Max - Min;
                for (int row = 0; row < Inputs.GetLength(0); ++row)
                {
                    Result[row][column] = (Inputs[row][column] - Min) / Difference;
                }
            }
            return Result;
        }

        public static double[,] NormalizeTheData(double[,] Inputs)
        {
            var Result = new double[Inputs.GetLength(0), Inputs.GetLength(1)];

            for (int column = 0; column < Inputs.GetLength(1); ++column)
            {
                //Average input for neuron
                var Sum = 0.0;
                for (int row = 0; row < Inputs.GetLength(0); row++) Sum += Inputs[row, column];

                var Average = Sum / Inputs.GetLength(0);

                //Standard deviation for neuron
                Sum = 0;
                for (int row = 0; row < Inputs.GetLength(0); row++)
                {
                    Sum += Math.Pow(Inputs[row, column] - Average, 2);
                }
                var StandardDeviation = Math.Sqrt(Sum / Inputs.GetLength(0));


                for (int row = 0; row < Inputs.GetLength(0); row++)
                {
                    Result[row, column] = (Inputs[row, column] - Average) / StandardDeviation;
                }
            }

            return Result;
        }
    }

    public static class ExtensionMethods
    { 
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];

            int size;

            if (typeof(T) == typeof(bool))
                size = 1;
            else if (typeof(T) == typeof(char))
                size = 2;
            else
                size = Marshal.SizeOf<T>();

            Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

            return result;
        }
    }
}
