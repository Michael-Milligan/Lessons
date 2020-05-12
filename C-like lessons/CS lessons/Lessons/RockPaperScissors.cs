using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Lessons
{
    class RockPaperScissors
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            string[][] Rounds = new string[Input.Length - 1][];
            int[] Wins = new int[2];

            for (int i = 0; i < Rounds.GetLength(0); ++i)
            {
                Rounds[i] = Input[i + 1].Split();
            }

            string Round = "";

            for (int i = 0; i < Rounds.GetLength(0); ++i)
            {
                Wins = new int[2];
                for (int j = 0; j < Rounds[i].Length; ++j)
                {
                    Round = Rounds[i][j];
                    if (Methods.WhoWon(Round) == 1) ++Wins[1];
                    else if (Methods.WhoWon(Round) == 0) ++Wins[0];
                }
                if (Wins[0] > Wins[1]) Console.Write("1 ");
                else Console.Write("2 ");
            }
        }
    }
}
