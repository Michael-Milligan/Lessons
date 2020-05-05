using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class RotateString
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] RawInput = File.ReadAllLines(Path);
            string[][] Input = new string[RawInput.Length - 1][];

            for (int i = 0; i < Input.Length; ++i)
            {
                Input[i] = RawInput[i + 1].Split();
                Methods.RotateString(ref Input[i][1], Convert.ToInt32(Input[i][0]));
                Console.WriteLine(Input[i][1]);
            }
            
        }
    }
}
