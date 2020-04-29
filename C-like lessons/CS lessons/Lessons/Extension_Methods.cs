using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public static class Extension_Methods
    {
        public static int Find(this Array array, object Object)
        {
            var enumerator = array.GetEnumerator();
            int i = 0;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == Object) return i;
                ++i;
            }
            return -1;
        }

        public static int Find(this string String, char Char)
        {
            int Index = 0;

            for (int i = 0; i < String.Length; ++i)
            {
                if (String[Index] == Char) return Index;
                ++Index;
            }
            return -1;
        }
    }
}
