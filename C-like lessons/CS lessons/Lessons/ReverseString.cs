using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class ReverseString
    {
        public static void Main()
        {
            string Path = "Resources.txt";
            string[] Input = File.ReadAllLines(Path);

            Methods.ReverseString(ref Input[0]);;

            Console.WriteLine(Input[0]);
        }
    }
}
