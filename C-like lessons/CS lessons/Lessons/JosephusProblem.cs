using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class JosephusProblem
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            int[] Input = File.ReadAllLines(Path)[0].
                Split().
                Select(number => Convert.ToInt32(number)).
                ToArray();

            int[] Array = new int[Input[0]];

            for (int i = 0; i < Array.Length; ++i)
            {
                Array[i] = i + 1;
            }

            while (Array.Length != 1)
            {
                for (int i = 0; i < Array.Length; ++i)
                {
                    if (i == 3) Array[i] = -1;
                }
                Array = Array.Where(number => number != -1).ToArray();
            }
            Console.WriteLine(Array[0]);
        }
    }
}
