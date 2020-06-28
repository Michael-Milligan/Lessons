using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class BinarySearch
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            int[] Input = File.ReadAllLines(Path)[0].
                Split().
                Select(number => Convert.ToInt32(number)).
                ToArray();

            int[] Numbers = new int[Input[0]];

            
        }
    }
}
