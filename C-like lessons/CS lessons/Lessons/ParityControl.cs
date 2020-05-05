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

            string[] Numbers = File.ReadAllText(Path).
                Split().
                Select(number => (Convert.ToString(Convert.ToInt32(number), 2))).
                ToArray();

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = Numbers[i].PadLeft(8, '0');
            }

            string[] SubNumbers = new string[Numbers.Length];

            for (int i = 0; i < SubNumbers.Length; ++i)
            {
                SubNumbers[i] = Numbers[i].Clone() as string;
                SubNumbers[i] = SubNumbers[i].Remove(0, 1);
            }

            int Sum = 0; 
            string Remainder = "";

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Sum = SubNumbers[i].Sum(digit => Convert.ToInt32(digit) - '0');
                Remainder = Convert.ToString((Sum) % 2);
                if (Remainder != Convert.ToString(Numbers[i][0]))
                    SubNumbers[i] = "-1";
            }

            SubNumbers = SubNumbers.Where(item => item != "-1").ToArray();
            int Code = 0;

            foreach (var item in SubNumbers)
            {
                Code = Convert.ToInt32(item, 2);
                Console.Write((char)Code);
            }
        }
    }
}
