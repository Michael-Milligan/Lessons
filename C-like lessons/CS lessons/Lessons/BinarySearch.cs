using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

namespace Lessons
{
    class BinarySearch
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] RawInput = File.ReadAllLines(Path);

            double[][] Numbers = new double[RawInput.Length - 1][];
            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = RawInput[i + 1].
                    Split().Select(number => Convert.ToDouble(number)).
                    ToArray();
            }

            double a = 0, b = 0, c = 0, d = 0,
                yRight = 1, yLeft = 1, yCenter = 0,
                RightBorder = 100, LeftBorder = 0;

            foreach (var Condition in Numbers)
            {
                a = Condition[0];
                b = Condition[1];
                c = Condition[2];
                d = Condition[3];

                yRight = 1;
                yLeft = 1;
                yCenter = 0;
                RightBorder = 100;
                LeftBorder = 0;

                while (true)
                {
                    yLeft = Methods.CalculateFunction(LeftBorder, a, b, c, d);
                    yRight = Methods.CalculateFunction(RightBorder, a, b, c, d);
                    yCenter = Methods.CalculateFunction((RightBorder + LeftBorder)/2, 
                        a, b, c, d);

                    if (yCenter < 0.0000001 && yCenter > -0.0000001) break;

                    if (yCenter > 0)
                    {
                        RightBorder = (RightBorder + LeftBorder) / 2;
                    }
                    else
                    {
                        LeftBorder = (RightBorder + LeftBorder) / 2;
                    }
                }
                Console.WriteLine((RightBorder + LeftBorder)/2);
            }

            //foreach (var result in Results)
            //{
            //    Console.Write(result + " ");
            //}
        }
    }
}
