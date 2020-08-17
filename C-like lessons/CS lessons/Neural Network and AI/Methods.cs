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
        public static void SerializeNetwork(ref NeuralNetwork NeuralNetwork)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream("1.dat", FileMode.Create))
            {
                Formatter = new BinaryFormatter();
                Formatter.Serialize(Stream, NeuralNetwork);
            }
        }

        public static void DeserializeNetwork(out NeuralNetwork NeuralNetwork)
        {
            BinaryFormatter Formatter;
            using (FileStream Stream = new FileStream("1.dat", FileMode.Open))
            {
                Formatter = new BinaryFormatter();
                NeuralNetwork = Formatter.Deserialize(Stream) as NeuralNetwork;
            }
        }

        public static DataObject[] ReadCSV(string Path)
        {
            string[] Strings = File.ReadAllLines(Path);
            string[][] Data = new string[Strings.Length][];
            for (int i = 0; i < Data.GetLength(0); ++i)
            {
                Data[i] = Strings[i].Split(',');
            }

            DataObject[] Results = new DataObject[Strings.Length - 1];

            for (int i = 0; i < Results.Length; ++i)
            {
                Results[i] = new DataObject()
                {
                    Age = Convert.ToInt32(Data[i + 1][0]),
                    Sex = Convert.ToInt32(Data[i + 1][1]),
                    ChestPainType = Convert.ToInt32(Data[i + 1][2]),
                    RestingBloodPressure = Convert.ToInt32(Data[i + 1][3]),
                    Cholesterol = Convert.ToInt32(Data[i + 1][4]),
                    Sugar = Convert.ToInt32(Data[i + 1][5]),
                    RestingECG = Convert.ToInt32(Data[i + 1][6]),
                    MaxHeartRate = Convert.ToInt32(Data[i + 1][7]),
                    ExerciseInducedAngina = Convert.ToInt32(Data[i + 1][8]),
                    OldPeak = Convert.ToDouble(Data[i + 1][9]),
                    SlopeOfThePeak = Convert.ToInt32(Data[i + 1][10]),
                    NumberOfMajorVessel = Convert.ToInt32(Data[i + 1][11]),
                    Defect = Convert.ToInt32(Data[i + 1][12]),
                    Target = Convert.ToInt32(Data[i + 1][13])
                };
            }
            return Results;
        }

        public class DataObject
        {
            public int Age;
            public int Sex;
            public int ChestPainType;
            public int RestingBloodPressure;
            public int Cholesterol;
            public int Sugar;
            public int RestingECG;
            public int MaxHeartRate;
            public int ExerciseInducedAngina;
            public double OldPeak;
            public int SlopeOfThePeak;
            public int NumberOfMajorVessel;
            public int Defect;
            public int Target;
        }
    }
}
