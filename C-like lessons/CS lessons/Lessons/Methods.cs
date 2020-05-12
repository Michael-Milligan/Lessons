using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lessons
{
    public class Methods
    {
        public static double Root(int Number, int Rounds)
        {
            double Result = 1;

            for (int i = 0; i < Rounds; ++i)
            {
                Result = (Result + Number / Result) / 2;
            }

            return Result;
        }

        public static int PerformOperation(char Sign, int FirstOperand, int SecondOperand)
        {
            switch (Sign)
            {
                case '+':
                    return FirstOperand + SecondOperand;
                case '*':
                    return FirstOperand * SecondOperand;
                case '%':
                    return FirstOperand % SecondOperand;
            }
            return 0;
        }

        public static int ToSeconds(int Days, int Hours, int Minutes, int Seconds)
        {
            return Days * 24 * 3600 +
                    Hours * 3600 +
                    Minutes * 60 +
                    Seconds;
        }

        public static int TriangleCanBeBuilt(int a, int b, int c)
        {
            if (a + b > c && b + c > a && a + c > b) return 1;
            return 0;
        }

        public static double CalculateBMI(int Weight, double Height)
        {
            return Weight / (Height * Height);
        }

        public static string AnalyseBMI(double BMI)
        {
            if (BMI < 18.5) return "under";
            else if (BMI < 25.0) return "normal";
            else if (BMI < 30.0) return "over";
            else return "obese";
        }

        public static int Median(string[] RawNumbers)
        {
            int[] Numbers = new int[RawNumbers.Length];
            List<int> MaxMin = new List<int>();

            for (int i = 0; i < Numbers.Length; ++i)
            {
                Numbers[i] = Convert.ToInt32(RawNumbers[i]);
            }

            var OrderedNumbers = Numbers.OrderBy(number => number);
            return OrderedNumbers.ElementAt(1);
        }

        public static int SumOfProgression(int Begin, int Increment, int NumberOfElements)
        {
            int Result = Begin;
            int NumberToSum = Begin;
            for (int i = 0; i < NumberOfElements - 1; ++i)
            {
                NumberToSum += Increment;
                Result += NumberToSum;
            }
            return Result;
        }

        public static int SumOfDigits(int Number)
        {
            int Result = 0;
            while (Number > 0)
            {
                Result += Number % 10;
                Number /= 10;
            }
            return Result;
        }

        public static bool IsVowel(char Char)
        {
            if ("eyuioa".Contains(Char)) return true;
            else return false;
        }

        public static int CountVowels(string String)
        {
            int Counter = 0;
            foreach (var character in String.ToLower())
            {
                if (IsVowel(character)) ++Counter;
            }
            return Counter;
        }

        public static int Round(double Number)
        {
            if (Number > 0)
            {
                if ((Number % 1) >= 0.5)
                {
                    return ((int)Number + 1);
                }
                else
                {
                    return (int)Number;
                }
            }
            else
            {
                if (Math.Abs((Number % 1)) >= 0.5)
                {
                    return ((int)Number - 1);
                }
                else
                {
                    return (int)Number;
                }
            }
        }

        public static char AnotherBracket(char Bracket)
        {
            string BracketString = "{}<>()[]";
            for (int i = 0; i < BracketString.Length; ++i)
            {
                if (BracketString[i] == Bracket) return BracketString[i - 1];
            }
            return ' ';
        }

        public static bool IsOpening(char Bracket)
        { return "{[(<".Contains(Bracket); }

        public static int Checksum(int[] Numbers, int Begin, int End)
        {
            int Result = 0;
            for (int i = Begin; i < End; ++i)
            {
                Result += Numbers[i];
                Result *= 113;
                Result %= 10000007;
            }
            return Result;
        }

        public static int Neumann(int Number)
        {
            string NumberInString = Convert.ToString(Number);

            Number *= Number;
            Number /= 100;
            Number %= 10000;
            return Number;
        }

        public static string ReverseString(ref string String)
        {
            char[] Chars = String.ToCharArray();

            char temp = ' ';

            for (int i = 0; i < Chars.Length / 2; ++i)
            {
                temp = Chars[i];
                Chars[i] = Chars[Chars.Length - i - 1];
                Chars[Chars.Length - i - 1] = temp;
            }
            String = new string(Chars);
            return String;
        }

        public static string RotateString(ref string String, int Number)
        {
            char[] Chars = String.ToCharArray();

            char temp = ' ';
            int Counter = 0;

            if (Number > 0)
            {
                for (Counter = 0; Counter < Number;++Counter)
                {
                    for (int i = 1; i < Chars.Length; ++i)
                    {
                        temp = Chars[i];
                        Chars[i] = Chars[i - 1];
                        Chars[i - 1] = temp;
                    }
                }
            }
            else if (Number < 0)
            {
                for (Counter = 0; Counter < Math.Abs(Number); ++Counter)
                {
                    for (int i = Chars.Length - 1; i >= 1; --i)
                    {
                        temp = Chars[i];
                        Chars[i] = Chars[i - 1];
                        Chars[i - 1] = temp;
                    }
                }
            }

            String = new string(Chars);
            return String;
        }

        public static double Function(double x, double a, double b, double c, double d)
        {
            return a * x + b * Math.Sqrt(Math.Pow(x, 3)) - c * Math.Exp(-x / 50) - d;
        }

        public static double[] CalculateSides(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            double[] Sides = new double[3];

            Sides[0] = Math.Pow(Math.Pow(x1-x2, 2) + Math.Pow(y1-y2, 2), 0.5);
            Sides[1] = Math.Pow(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2), 0.5);
            Sides[2] = Math.Pow(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2), 0.5);

            return Sides;
        }

        public static double CalculateArea(double[] Sides)
        {
            double Halfperimeter = (Sides[0] + Sides[1] + Sides[2])/2;

            return Math.Pow(Halfperimeter * 
                (Halfperimeter - Sides[0]) * 
                (Halfperimeter - Sides[1]) * 
                (Halfperimeter - Sides[2]), 0.5);
        }

        public static int WhoWon(string Round)
        {
            if (Round[0] == 'S' && Round[1] == 'R') return 1;
            if (Round[0] == 'P' && Round[1] == 'S') return 1;
            if (Round[0] == 'R' && Round[1] == 'P') return 1;

            if (Round[0] == Round[1]) return 2;

            return 0;
        }

        public static double CalculateFunction
            (double x, double a, double b, double c, double d)
        {
            return a * x + b * Math.Pow(x, 1.5) - c * Math.Exp(-x / 50) - d;
        }
    }
}
