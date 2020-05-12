using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class TriangleArea
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            int[][] Coordinates = new int[Input.Length - 1][];

            for (int i = 1; i < Coordinates.GetLength(0) + 1; ++i)
            {
                Coordinates[i - 1] = Input[i].
                    Split().
                    Select(number => Convert.ToInt32(number)).
                    ToArray();
            }

            double[] Sides;

            foreach (var Condition in Coordinates)
            {
                Sides = Methods.CalculateSides(Condition[0],
                    Condition[1],
                    Condition[2],
                    Condition[3],
                    Condition[4],
                    Condition[5]);

                Console.WriteLine(Methods.CalculateArea(Sides));
            }
        }
    }
}
