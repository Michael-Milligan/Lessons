using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLessons
{
    class Model : BindableBase
    {
        public readonly ObservableCollection<int> Numbers = 
            new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> PublicNumbers;

        public int Sum => Numbers.Sum();

        public void RemoveValue(int Index)
        {
            if (Index >= 0 && Index < Numbers.Count)
            {
                Numbers.RemoveAt(Index);
                RaisePropertyChanged("Sum");
            }
        }

        public void AddValue(int Value)
        {
            Numbers.Add(Value);
            RaisePropertyChanged("Sum");
        }

        public Model()
        {
            PublicNumbers =
            new ReadOnlyObservableCollection<int>(Numbers);
        }
    }
}
