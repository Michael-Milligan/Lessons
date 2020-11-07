using System;

namespace Data_Structures_and_Algorithms
{
    class Program
    {
        static void Main()
        {
            SkipList<int> SL = new SkipList<int>(4);
            for (int i = 0; i < 16; ++i)
            {
                SL.Add(i);
            }
            SL.PrintList();
        }
    }
}
