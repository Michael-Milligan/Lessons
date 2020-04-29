using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lessons
{
    public class ProgramWithMultipleArguments
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] RawInput = File.ReadAllLines(Path);

            int NumberOfElements = Convert.ToInt32(RawInput[0]);
            int[][] Numbers = new int[NumberOfElements][];

            for (int i = 0; i < NumberOfElements; ++i)
            {
                Numbers[i] = RawInput[i + 1].Split().
                    Select(number => Convert.ToInt32(number)).
                    ToArray();
            }

            List<int> Results = new List<int>();
            float temp = 0;

            foreach (var condition in Numbers)
            {
                checked { temp = ((float)condition[2] / (1 / (float)condition[0] + 1 / (float)condition[1])); }
                Results.Add(Methods.Round(temp));
            }

            //Console.WriteLine(Result);

            foreach (var result in Results)
            {
                Console.Write(result + " ");
            }

            //for (int i = 0; i < NumberOfElements * 4; i += 4)
            //{
            //    Console.Write("(" + Results[i + 3] + " " + Results[i + 2] + " " + Results[i + 1] + " " + Results[i] + ") ");
            //}
        }


    }
}
