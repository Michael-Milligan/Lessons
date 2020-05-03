using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class SortWithIndexes
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] RawInput = File.ReadAllLines(Path);

            int[] Numbers = RawInput[1].
                Split().
                Select(number => Convert.ToInt32(number)).
                ToArray();

            Dictionary<int, int> Array = new Dictionary<int, int>();

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Array.Add(Numbers[i], i);
            }

            int[] OrderedNumbers = Numbers.OrderBy(number => number).ToArray();

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Console.WriteLine((Array[OrderedNumbers[i]] + 1) + " ");
            }
        }
    }
}
