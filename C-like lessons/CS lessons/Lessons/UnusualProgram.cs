using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    public class UnusualProgram
    {
        static string BracketString = "()[]{}<>";

        public static void Main()
        {
            string Path = "Resources.txt";

            string[] RawInput = File.ReadAllLines(Path);

            int NumberOfElements = Convert.ToInt32(RawInput[0]);

            string[] Strings = new string[NumberOfElements];

            for (int i = 0; i < NumberOfElements; ++i)
            {
                Strings[i] = RawInput[i + 1];
            }

            Stack<char> Brackets = new Stack<char>();

            List<int> Results = new List<int>();

            for (int i = 0; i < NumberOfElements; ++i)
            {
                Strings[i] = new string(Strings[i].Where(Char => BracketString.Contains(Char)).ToArray());
            }

            foreach (var String in Strings)
            {
                while (String != "")
                {
                    if (String.First() == AnotherBracket(String.Last()))
                    {
                        String.Remove(0, 1);
                        String.Remove(String.Length, 1);
                    }

                    //if ()

                }

                foreach (var result in Results)
                {
                    Console.Write(result + " ");
                }
            }
        }

        public static char AnotherBracket(char Bracket)
        {
            for (int i = 0; i < BracketString.Length; ++i)
            {
                if (BracketString[i] == Bracket) return BracketString[i - 1];
            }
            return ' ';
        }
    }

    public static class Extension_Methods
    {
        public static int Find(this Array array, object Object)
        {
            var enumerator = array.GetEnumerator();
            int i = 0;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == Object) return i;
                ++i;
            }
            return -1;
        }

        public static int Find(this string String, char Char)
        {
            int Index = 0;

            for (int i = 0; i < String.Length; ++i)
            {
                if (String[Index] == Char) return Index;
                ++Index;
            }
            return -1;
        }
    }
}