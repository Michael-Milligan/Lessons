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
            var result = Function(",[.[-],]", input);
        }

        public static string Function(string code, string input)
        {
            byte[] memory = new byte[3000];
            int inputIndex = 0, memoryIndex = 0;
            string result = "";
            for (int codeIndex = 0; codeIndex < code.Length;)
            {
                switch (code[codeIndex])
                {
                    case '<':
                        ++memoryIndex; ++codeIndex;
                        break;
                    case '>':
                        --memoryIndex; ++codeIndex;
                        break;
                    case '+':
                        ++memory[memoryIndex]; ++codeIndex;
                        break;
                    case '-':
                        --memory[memoryIndex]; ++codeIndex;
                        break;
                    case '.':
                        result += (char)memory[memoryIndex]; ++codeIndex;
                        break;
                    case ',':
                        memory[memoryIndex] = (byte)input[inputIndex++]; ++codeIndex;
                        break;
                    case '[':
                        if (memory[memoryIndex] != 0) ++codeIndex;
                        else codeIndex = code[codeIndex..].IndexOf(']') + 1;
                        break;
                    case ']':
                        if (memory[memoryIndex] == 0) ++codeIndex;
                        else codeIndex -= code[..codeIndex].Reverse().ToList().IndexOf('['); 
                        break;
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
