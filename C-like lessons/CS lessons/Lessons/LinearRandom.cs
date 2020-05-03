using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Lessons
{
    class LinearRandom
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] RawInput = File.ReadAllLines(Path);

            int[][] Numbers = new int[RawInput.Length - 1][];

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = RawInput[i + 1].Split().
                    Select(number => Convert.ToInt32(number)).
                    ToArray();
            }

            int A = 0, C = 0, M = 0, X = 0, N = 0;

            foreach (var condition in Numbers)
            {
                A = condition[0];
                C = condition[1];
                M = condition[2];
                X = condition[3];
                N = condition[4];

                for (int i = 0; i < N; ++i)
                {
                    X = (A * X + C) % M;
                }

                Console.WriteLine(X + " ");
            }
        }
    }
}
