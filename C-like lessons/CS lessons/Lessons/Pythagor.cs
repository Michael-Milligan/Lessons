using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class Pythagor
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] RawInput = File.ReadAllLines(Path);

            int[][] Numbers = new int[RawInput.Length - 1][];

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = RawInput[i + 1].
                    Split().
                    Select(number => Convert.ToInt32(number)).
                    ToArray();
            }

            foreach (var condition in Numbers)
            {
                if (Methods.IsRightTriangle(condition)) Console.Write("R ");
                else if (Methods.IsObtuse(condition)) Console.Write("O ");
                else Console.Write("A ");
            }
        }
    }
}
