using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class CountBits
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            int[] Numbers = Input[1].
                Split().
                Select(number => Convert.ToInt32(number)).
                ToArray();

            string[] NumbersInBinary = Numbers.
                Select(number => Convert.ToString(number, 2)).
                ToArray();

            foreach (var number in NumbersInBinary)
            {
                char[] Number = number.ToCharArray();
                Number = Number.Where(bit => bit == '1').ToArray();
                Console.WriteLine(Number.Length);
            }
        }
    }
}
