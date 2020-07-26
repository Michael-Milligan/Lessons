using Prism.Mvvm;
using Savage.Range;

namespace WPFLessons
{
    class Model : BindableBase
    {
        public Model()
        {
            int[] Array = new int[5];
            Array.Initialize();
            var a = Array[1..2];
            Range<int> b = new Range<int>(1, 5); 
        }
    }
}
