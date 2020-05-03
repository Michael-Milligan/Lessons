using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lessons
{
    class Bubble_in_Array
    {
        class ProgramWithOneArgument
        {
            public static void Main()
            {
                string Path = "Resources.txt";
                string[] RawInput = File.ReadAllLines(Path);

                //int NumberOfAnswers = Convert.ToInt32(RawInput[0].Split()[0]);

                int[] Numbers = RawInput[0].
                                    Split().
                                    Select(rawnumber => Convert.ToInt32(rawnumber)).
                                    ToArray();

                //int[] Results = new int[NumberOfAnswers];

                //for (int i = 0; i < Results.Length; ++i)
                //{
                //    Results[i] = Numbers.Where(number => number == (i + 1)).Count();
                //}
                //List<int> Results = new List<int>();

                int Counter = 0;

                Console.WriteLine();

                for (int i = 1; i < Numbers.Length - 1; ++i)
                {
                    if (Numbers[i] < Numbers[i-1])
                    {
                        int temp = Numbers[i];
                        Numbers[i] = Numbers[i - 1];
                        Numbers[i - 1] = temp;
                        ++Counter;
                    }
                }

                Console.WriteLine(Counter + " " + Methods.Checksum(Numbers, 0, Numbers.Length - 1));

                //for (int i = 1; i < Results.Length; ++i)
                //{
                //    Console.WriteLine(Results[i] +" ");
                //}

                //foreach (var result in Results)
                //{
                //    Console.Write(result + " ");
                //}
                //Console.WriteLine(Result);
            }
        }
    }
}
