using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class BlackJack
    {
        public static void Main()
        {
            string Path = "Resources.txt";

            string[] Input = File.ReadAllLines(Path);

            string[][] Cards = new string[Input.Length - 1][];

            for (int i = 0; i < Cards.Length; ++i)
            {
                Cards[i] = Input[i + 1].Split();
            }

            int Sum = 0;

            foreach (var Condition in Cards)
            {
                Sum = 0;
                foreach (var Card in Condition)
                {
                    Sum += Methods.GetPoints(Card, Condition, Sum);
                }
                if (Sum < 22) Console.Write(Sum + " ");
                else Console.Write("Bust ");
            }
        }
    }
}
