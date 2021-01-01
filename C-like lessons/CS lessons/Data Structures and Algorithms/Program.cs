using System;
using Data_Structures_and_Algorithms.Structures;

namespace Data_Structures_and_Algorithms
{
    class Program
    {
        static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            Random random = new Random();
            for (int i = 0; i < 10; ++i)
            {
                try
                {
                    tree.Add(random.Next(0, 50));
                }
                catch (Exception) { }
            }

            tree.print2D(tree._Root);
        }
    }
}
