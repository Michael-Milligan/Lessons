using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lessons
{
    class Lesson
    {
        public static void Main()
        {
            DirectoryInfo Info = new DirectoryInfo("C:\\Users\\User\\Desktop\\1.txt");
            using (StreamReader Reader = new StreamReader(Info.))
            {

            }
        }
    }
}
