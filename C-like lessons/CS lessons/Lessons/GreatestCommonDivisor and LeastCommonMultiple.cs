using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class GCD_and_LCM
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

            int A = 0, B = 0, LeastCommonMultiple = 0;

            foreach (var condition in Numbers)
            {
                A = condition[0];
                B = condition[1];

                while (A != B)
                {
                    if (A < B) B -= A;
                    else A -= B;
                }

                LeastCommonMultiple = Methods.Round(condition[0] * condition[1] / A);

                Console.WriteLine("(" + A + " " + LeastCommonMultiple + ")");
            }
        }
    }
}