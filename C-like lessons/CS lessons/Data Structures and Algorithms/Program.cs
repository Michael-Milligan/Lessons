using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections;
using System.IO;

namespace Data_Structures_and_Algorithms
{
    public class Program
    {
        static Stopwatch clock = new Stopwatch();
        public static void Main()
        {

            Person I = new Person(19, new string[] { "Michel", "Raumond", "Faubert" });
            var (age, names) = I;
        }
    }

    public  record Person(int Age, string[] Names);

    public class BenchmarkClass
    {

    }

    public static class Extensions
    {
        
    }
}
