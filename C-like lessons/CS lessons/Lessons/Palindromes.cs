using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class Palindromes
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] Input = File.ReadAllLines(Path);
            
            string[] Results = new string[Input.Length - 1];

            string temp = "";

            for (int i = 1; i < Input.Length; ++i)
            {
                Input[i] = new string(Input[i].Where(Char => Char > 'A' && Char < 'Z' || Char > 'a' && Char < 'z').ToArray());
                temp = new string(Input[i].Reverse().ToArray());
                if (Input[i].ToLower() == temp.ToLower()) Results[i - 1] = "Y";
                else Results[i - 1] = "N";
            }

            foreach (var result in Results)
            {
                Console.Write(result + " ");
            }
        }
    }
}
