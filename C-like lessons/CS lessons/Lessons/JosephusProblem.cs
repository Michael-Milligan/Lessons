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

            int[] Numbers = new int[Input[0]];

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = i + 1;
            }

            int Counter = 0, StartPosition = 0; ;

            while (Numbers.Where(number => number != -1).Count() != 1)
            {
                for (int i = StartPosition; i < Numbers.Length; ++i)
                {
                    if (Numbers[i] != -1) ++Counter;
                    if (Counter == Input[1])
                    {
                        Numbers[i] = -1;
                        Counter = 0;
                        if (i == Numbers.Length - 1)
                        {
                            StartPosition = 0;
                            break;
                        }
                        else
                        {
                            StartPosition = i + 1;
                            break;
                        }
                    }
                    if (i == Numbers.Length - 1) i = -1;
                    if (Numbers.Where(number => number != -1).Count() == 1) break;
                }
            }

            Numbers = Numbers.
                    Where(number => number != -1).
                    ToArray();

            Console.WriteLine(Numbers[0]);
        }
    }
}
