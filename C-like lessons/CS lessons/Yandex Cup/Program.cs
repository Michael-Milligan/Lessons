using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yandex_Cup
{
    class Program
    {

        static void  Main()
        {
            string Input = Console.ReadLine();
            List<string> Palindromes = new List<string>();
            int Min = 1000;


            for (int i = 0; i < Input.Length; ++i)
            {
                for (int j = 0; j <= Input.Length; ++j)
                {
                    if (j > 1 && j <= Min)
                    {
                        try
                        {
                            string temp = Input.Substring(i, j);
                            if (IsPalindromeAsync(temp).Result)
                            {
                                Palindromes.Add(temp);
                                Min = temp.Length;
                            }
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
                int NeededLength = Palindromes.Min(item => item.Length);

                Palindromes = Palindromes.AsParallel().
                    Where(item => item.Length == NeededLength).
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
            if (temp <= 1) throw new Exception();
            int Max = (int)(temp / 2);
            for (int i = 0; i < Max; ++i)
            {
                if (Data[i] != Data[temp - i - 1]) return false;
            }
            return true;
        }

        public static async Task<bool> IsPalindromeAsync(string Data) =>
            await Task.Run(() => IsPalindrome(Data));
    }
}