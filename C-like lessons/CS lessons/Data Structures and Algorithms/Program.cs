using System;

namespace Data_Structures_and_Algorithms
{
    class Program
    {
        static void Main()
        {
            SkipList<int> SL = new SkipList<int>(5);
            for (int i = 1; i <= 25; ++i)
            {
                SL.Add(i);
            }
            SL.PrintList();
            SL.Delete(4);
            Console.WriteLine();
            SL.PrintList();
            Console.WriteLine();
            SL.Add(80);
            SL.PrintList();

            Console.WriteLine();
            SL.Add(70);
            SL.PrintList();

            //TODO: Make Add fill spaces made by Delete
        }
    }
}
