using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Yandex_Cup
{
    class Program
    {
        static int Min = 1000;
        static List<string> Palindromes;
        static int i = 0, j = 0;
        static object x;

        static void Main()
        {
            x = new object();
            //string Input = String.Concat(Enumerable.Repeat("tftf", 150));
            string Input = Console.ReadLine();
            Palindromes = new List<string>();
            
            for (i = 0; i < Input.Length; ++i)
            {
                for (j = 2; j <= Input.Length; ++j)
                {
                    if (j <= Min)
                    {
                        try
                        {
                            string temp = Input.Substring(i, j);
                            CheckAndAddAsync(temp);
                        }
                        catch { }
                        
                    }
                }
            }


            if (Palindromes.Count == 1)
            {
                Console.WriteLine(Palindromes[0]);
                return;
            }

            try
            {
                Palindromes = Palindromes.AsParallel().
                    Where(item => item.Length == Min).
                    ToList();

                Palindromes = Palindromes.OrderBy(item => item[0]).ToList();
            }
            catch { }
            try
            {
                Console.WriteLine(Palindromes[0]);
            }
            catch (Exception) 
            {
                Console.WriteLine(-1);
            }
        }

        public static bool IsPalindrome(string Data)
        {
            int temp = Data.Length;
            int Max = (int)(temp / 2);
            for (int i = 0; i < Max; ++i)
            {
                if (Data[i] != Data[temp - i - 1]) return false;
            }
            //Console.WriteLine(DateTime.Now.Second + " " + DateTime.Now.Millisecond);
            //Thread.Sleep(8000);
            return true;
        }

        public static void CheckAndAdd(string Data)
        {
            if (IsPalindrome(Data))
            {
                lock (x)
                {
                    Palindromes.Add(Data);
                }
                Min = Data.Length;
            }
        }

        public static async void CheckAndAddAsync(string Data) => await Task.Run(() => CheckAndAdd(Data));
    }
}