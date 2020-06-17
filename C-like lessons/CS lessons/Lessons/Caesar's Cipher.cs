using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class Caesar_s_Cipher
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            int Coefficient = Convert.ToInt32(Input[0].
                Split()[1]);

            char[][] Codes = new char[Input.Length - 1][];

            for (int i = 1; i < Input.Length; ++i)
            {
                Codes[i - 1] = Input[i].ToCharArray();
            }

            for (int i = 0; i < Codes.GetLength(0); ++i)
            {
                for (int j = 0; j < Codes[i].Length; ++j)
                {
                    if (Codes[i][j] != '.' && Codes[i][j] != ' ') 
                        Codes[i][j] = (char)((Codes[i][j] - Coefficient % 90));
                    if (Codes[i][j] < 65 && Codes[i][j] != '.' && Codes[i][j] != ' ') Codes[i][j] = (char)(Codes[i][j] + 26);
                }
                Console.WriteLine(new string(Codes[i]));
            }
        }
    }
}
