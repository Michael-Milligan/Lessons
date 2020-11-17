using System;

namespace Data_Structures_and_Algorithms
{
    class Program
    {
        static void Main()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Add(4, 0);
            queue.Add(5, 1);
            queue.Add(6, 2);
            queue.Add(7, 1);
            queue.Add(8, 0);

            foreach (int item in queue)
            {
                Console.Write(item.ToString() + '\t');
            }

            Console.WriteLine();
            var a = queue.GetTop();
            foreach (int item in queue)
            {
                Console.Write(item.ToString() + '\t');
            }

            Console.WriteLine();
            _ = queue.PopTop();
            foreach (int item in queue)
            {
                Console.Write(item.ToString() + '\t');
            }
            Console.WriteLine();
        }
    }
}
