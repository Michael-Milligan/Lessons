using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class Mortgage
    {
        public static void Main()
        {
            double[] Input = Console.ReadLine().
                Split().
                Select(number => Convert.ToDouble(number)).
                ToArray();

            double Loan = Input[0], Percent = Input[1], Months = Input[2], Payment = 0;

            double Sum = 0;

            for (int i = 0; i < Months; ++i)
            {
                Sum += Loan*Percent/1200+
            }
        }
    }
}
