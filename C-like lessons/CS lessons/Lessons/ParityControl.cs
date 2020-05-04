using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class ParityControl
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            int[] Numbers = File.ReadAllText(Path).
                Split().
                Select(number => Convert.ToInt32(Convert.ToString(Convert.ToInt32(number), 2))).
                ToArray();

            for (int i = 0; i < Numbers.Length; ++i)
            {
                if
            }
        }
    }
}
