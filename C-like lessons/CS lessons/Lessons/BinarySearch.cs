using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class BinarySearch
    {
        //public static void Main()
        //{
        //    string Path = "Resources.txt";
        //    string[] RawInput = File.ReadAllLines(Path);

        //    double[][] Numbers = new double[RawInput.Length - 1][];
        //    for (int i = 0; i < Numbers.Length; ++i)
        //    {
        //        Numbers[i] = RawInput[i + 1].
        //            Split().Select(number => Convert.ToDouble(number)).
        //            ToArray();
        //    }

        //    double x = 0, a = 0, b = 0, c = 0, d = 0, PreviousX = 1, y = 0, PreviousY = 1;

        //    List<double> Results = new List<double>();

        //    for (int i = 0; i < Numbers.Length; ++i)
        //    {
        //        x = 0;
        //        PreviousX = 1;
        //        a = Numbers[i][0];
        //        b = Numbers[i][1];
        //        c = Numbers[i][2];
        //        d = Numbers[i][3];

        //        while(y > 0.0000001)
        //        {
        //            PreviousX = x;
        //            PreviousY = y;
        //            y = Methods.Function(x, a, b, c, d);
        //            if (y < PreviousY) x += 0.0000001;
        //            else x -= 0.0000001;
        //        }

        //        Results.Add(x);
        //    }

        //    foreach (var result in Results)
        //    {
        //        Console.Write(result + " ");
        //    }
        //}
    }
}
