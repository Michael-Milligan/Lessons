using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class MatchingWords
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            string[] Words = Input[0].Split();

            Words = Words.OrderBy(value => value).ToArray();

            for (int i = 0; i < Words.Length; ++i)
            {
                if (Words.Where(word => word == Words[i]).Count() > 1)
                {
                    Console.WriteLine(Words[i]);
                }
                Words = Words.Where(word => word != Words[i]).ToArray();
                i = 0;
            }
        }
    }
}

