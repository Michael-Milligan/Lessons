using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class NeumannRandom
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] RawInput = File.ReadAllLines(Path);

            int[] Numbers = RawInput[1].Split().
                Select(item => Convert.ToInt32(item)).
                ToArray();

            int[] Results = Numbers.Select(item => item).ToArray();
            int[] Counters = new int[Results.Length];

            List<int> Sequence = new List<int>();

            bool IsFound = false;

            for (int i = 0; i < Numbers.Length; ++i)
            {
                IsFound = false;
                Sequence.Clear();
                do
                {
                    Results[i] = Methods.Neumann(Results[i]);
                    Sequence.Add(Results[i]);

                    for (int j = 0; j < Sequence.Count - 1; ++j)
                    {
                        if (Sequence[j] == Results[i]) 
                        {
                            IsFound = true;
                            break; 
                        }
                    }
                }
                while (!IsFound);

                Sequence = Sequence.Distinct().ToList();

                Console.WriteLine((Sequence.Count + 1) + " ");
            }
        }
    }
}
