using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons
{
    //public class ProgramWithMultipleArguments
    //{
    //    public static void Main()
    //    {
    //        int NumberOfElements = Convert.ToInt32(Console.ReadLine());


    //        //List<string[]> Input = new List<string[]>();
    //        int[][] Numbers = new int[NumberOfElements][];

    //        List<double> Results = new List<double>();
    //        //Input.Add(Console.ReadLine().Split());
    //        //int Result = Convert.ToInt32(Input[0][0]);

    //        for (int i = 1; i < NumberOfElements; ++i)
    //        {
    //            Numbers[i] = Console.ReadLine().
    //                Split().
    //                Select(raw_number => Convert.ToInt32(raw_number)).
    //                ToArray();
    //        }



    //        //Console.WriteLine(Result);

    //        foreach (var result in Results)
    //        {
    //            Console.Write(result + " ");
    //        }

    //        //for (int i = 0; i < NumberOfElements * 4; i += 4)
    //        //{
    //        //    Console.Write("(" + Results[i + 3] + " " + Results[i + 2] + " " + Results[i + 1] + " " + Results[i] + ") ");
    //        //}
    //    }

    //    #region used functions
    //    public static double Root(int Number, int Rounds)
    //    {
    //        double Result = 1;

    //        for (int i = 0; i < Rounds; ++i)
    //        {
    //            Result = (Result + Number / Result) / 2;
    //        }

    //        return Result;
    //    }
        
    //    public static int PerformOperation(char Sign, int FirstOperand, int SecondOperand)
    //    {
    //        switch (Sign)
    //        {
    //            case '+':
    //                return FirstOperand + SecondOperand;
    //            case '*':
    //                return FirstOperand * SecondOperand;
    //            case '%':
    //                return FirstOperand % SecondOperand;
    //        }
    //        return 0;
    //    }

    //    public static int ToSeconds(int Days, int Hours, int Minutes, int Seconds)
    //    {
    //        return Days * 24 * 3600 +
    //                Hours * 3600 +
    //                Minutes * 60 +
    //                Seconds;
    //    }

    //    public static int TriangleCanBeBuilt(int a, int b, int c)
    //    {
    //        if (a + b > c && b + c > a && a + c > b) return 1;
    //        return 0;
    //    }

    //    public static double CalculateBMI(int Weight, double Height)
    //    {
    //        return Weight / (Height * Height);
    //    }

    //    public static string AnalyseBMI(double BMI)
    //    {
    //        if (BMI < 18.5) return "under";
    //        else if (BMI < 25.0) return "normal";
    //        else if (BMI < 30.0) return "over";
    //        else return "obese";
    //    }

    //    public static int Median(string[] RawNumbers)
    //    {
    //        int[] Numbers = new int[RawNumbers.Length];
    //        List<int> MaxMin = new List<int>();

    //        for (int i = 0; i < Numbers.Length; ++i)
    //        {
    //            Numbers[i] = Convert.ToInt32(RawNumbers[i]);
    //        }

    //        var OrderedNumbers = Numbers.OrderBy(number => number);
    //        return OrderedNumbers.ElementAt(1);
    //    }

    //    public static int SumOfProgression(int Begin, int Increment, int NumberOfElements)
    //    {
    //        int Result = Begin;
    //        int NumberToSum = Begin;
    //        for (int i = 0; i < NumberOfElements - 1; ++i)
    //        {
    //            NumberToSum += Increment;
    //            Result += NumberToSum;
    //        }
    //        return Result;
    //    }

    //    public static int SumOfDigits(int Number)
    //    {
    //        int Result = 0;
    //        while (Number > 0)
    //        {
    //            Result += Number % 10;
    //            Number /= 10;
    //        }
    //        return Result;
    //    }

    //    public static bool IsVowel(char Char)
    //    {
    //        if ("eyuioa".Contains(Char)) return true;
    //        else return false;
    //    }

    //    public static int CountVowels(string String)
    //    {
    //        int Counter = 0;
    //        foreach (var character in String.ToLower())
    //        {
    //            if (IsVowel(character)) ++Counter;
    //        }
    //        return Counter;
    //    }

    //    public static int Round(double Number)
    //    {
    //        if (Number > 0)
    //        {
    //            if ((Number % 1) >= 0.5)
    //            {
    //                return ((int)Number + 1);
    //            }
    //            else
    //            {
    //                return (int)Number;
    //            }
    //        }
    //        else
    //        {
    //            if (Math.Abs((Number % 1)) >= 0.5)
    //            {
    //                return ((int)Number - 1);
    //            }
    //            else
    //            {
    //                return (int)Number;
    //            }
    //        }
    //    }
    //    #endregion
    //}
}
