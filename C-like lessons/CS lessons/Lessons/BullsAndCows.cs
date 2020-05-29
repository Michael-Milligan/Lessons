using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class BullsAndCows
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            string SecretCode = Input[0].Split()[0];
            string[] Attempts = Input[1].Split();

            int RightPlace = 0, RightDigit = 0;

            foreach (var attempt in Attempts)
            {
                RightPlace = 0;
                RightDigit = 0;
                for (int i = 0; i < attempt.Length; ++i)
                {
                    if (attempt[i] == SecretCode[i]) ++RightPlace;
                    else if (SecretCode.Contains(attempt[i])) ++RightDigit;
                }
                Console.Write(RightPlace + "-" + RightDigit + " ");
            }
        }
    }
}
