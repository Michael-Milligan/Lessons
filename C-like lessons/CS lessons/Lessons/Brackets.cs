using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    //public class UnusualProgram
    //{
    //    static string BracketString = "()[]{}<>";

    //    public static void Main()
    //    {
    //        #region Debugged
    //        string Path = "Resources.txt";

    //        string[] RawInput = File.ReadAllLines(Path);

    //        int NumberOfElements = Convert.ToInt32(RawInput[0]);

    //        string[] Strings = new string[NumberOfElements];

    //        for (int i = 0; i < NumberOfElements; ++i)
    //        {
    //            Strings[i] = RawInput[i + 1];
    //        } 

    //        Stack<char> Brackets = new Stack<char>();

    //        List<int> Results = new List<int>();

    //        for (int i = 0; i < NumberOfElements; ++i)
    //        {
    //            Strings[i] = new string(Strings[i].Where(Char => BracketString.Contains(Char)).ToArray());
    //        }

    //        #endregion

    //        bool IsNotMatch = false;

    //        for (int i = 0; i<Strings.Length; ++i)
    //        {
    //            IsNotMatch = false;

    //            for (int j = 0; Strings[i].Length > 0; ++j)
    //            {
    //                if (IsOpening(Strings[i][j]))
    //                {
    //                    Brackets.Push(Strings[i][j]);
    //                    Strings[i] = Strings[i].Remove(0, 1);
    //                    --j;
    //                }
    //                else if (!IsOpening(Strings[i][j]) && Brackets.Peek() == AnotherBracket(Strings[i][j]))
    //                {
    //                    Brackets.Pop();
    //                    Strings[i] = Strings[i].Remove(0, 1);
    //                    --j;
    //                }
    //                else
    //                {
    //                    IsNotMatch = true;
    //                    break;
    //                }
    //            }

    //            if (IsNotMatch) Results.Add(0);
    //            else Results.Add(1);
    //        }
            
    //        foreach (var result in Results)
    //            {
    //                Console.Write(result + " ");
    //            }
    //    }

        
    //}
}