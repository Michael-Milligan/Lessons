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
            string input = "Codewars" + char.ConvertFromUtf32(255);
            var result = Function(",>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<+>>[-]]<<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++<[->-<]>++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<<<<<<[>>>+>+<<<<-]>>>>[<<<<+>>>>-]<-[>>.>.<<<[-]]<<[>>+>+<<<-]>>>[<<<+>>>-]<<[<+>-]>[<+>-]<<<-]", input);
        }

        public class Brace : IComparable
        {
            public char brace { get; set; }
            public int index { get; set; }

            public int CompareTo(object obj) => index - (obj as Brace).index;
        }

        public static string Function(string code, string input)
        {
            byte[] memory = new byte[3000];
            int inputIndex = 0, memoryIndex = 0;
            SortedSet<Brace> braces = new SortedSet<Brace>();
            string result = "";
            for (int codeIndex = 0; codeIndex < code.Length;)
            {
                var temp = code[codeIndex];
                if (temp == '[' || temp == ']') File.AppendAllText(@"D:\1.txt", $"{temp}: {codeIndex}\n");
                switch (temp)
                {
                    case '<': --memoryIndex; ++codeIndex;
                        break;
                    case '>': ++memoryIndex; ++codeIndex;
                        break;
                    case '+': ++memory[memoryIndex]; ++codeIndex;
                        break;
                    case '-': --memory[memoryIndex]; ++codeIndex;
                        break;
                    case '.': result += (char)memory[memoryIndex]; ++codeIndex;
                        break;
                    case ',': memory[memoryIndex] = (byte)input[inputIndex++]; ++codeIndex;
                        break;
                        //
                    case '[':
                        if (memory[memoryIndex] != 0)
                        {
                            braces.Add(new Brace() { brace = '[', index = codeIndex });
                            ++codeIndex;
                        }
                        else codeIndex = code[codeIndex..].Reverse().ToList().IndexOf(']') + 1;
                        
                        break;
                    case ']':
                        if (memory[memoryIndex] == 0)
                        {
                            ++codeIndex;
                            if (braces.Last().brace == '[') braces.Remove(braces.Last());
                            else
                            {
                                int index = 0;
                                for (index = braces.Count - 1; index >= 0 && braces.ElementAt(index).brace != '['; index--) { }
                                braces.Remove(braces.ElementAt(index));
                            }
                        }
                        else
                        {
                            if (braces.Last().brace == '[') codeIndex = braces.Last().index + 1;
                            else
                            {
                                while (true)
                                {
                                    int index = 0;
                                    for (index = braces.Count - 1; index >= 0 && braces.ElementAt(index).brace != '['; index--) { }
                                    codeIndex = braces.ElementAt(index).index;
                                }
                            }
                        }
                        break;
                        //
                    default: return "";
                }
            }
            return result;
        }
    }

    public class BenchmarkClass
    {

    }

    public static class Extensions
    {
        
    }
}
