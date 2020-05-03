using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class BubbleSort
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] RawInput = File.ReadAllLines(Path);

            int[] Numbers = RawInput[1].
                Split().
                Select(number => Convert.ToInt32(number)).
                ToArray();

            int Passes = 0, Swaps = 0;
            bool IsSorted = false;
            bool WasASwap = false;
            while (!IsSorted)
            {
                WasASwap = false;
                for (int i = 1; i < Numbers.Length; ++i)
                {
                    if (Numbers[i] < Numbers[i - 1])
                    {
                        ++Swaps;
                        int temp = Numbers[i];
                        Numbers[i] = Numbers[i - 1];
                        Numbers[i - 1] = temp;
                        WasASwap = true;
                    }
                }
                ++Passes;
                if (!WasASwap) IsSorted = true;
            }

            Console.WriteLine(Passes + " " + Swaps);
        }
    }
}