using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFLessons
{ 
    class VM : BindableBase
    {
        readonly Model Model = new Model();
        public ReadOnlyObservableCollection<int> MyValues => Model.PublicNumbers;

        public int Sum => Model.Sum;

        public DelegateCommand<int?> RemoveCommand { get; }
        public DelegateCommand<string> AddCommand { get; }

        public VM()
        {
            Model.PropertyChanged += (Sender, Args) =>
            { RaisePropertyChanged(Args.PropertyName); };

            AddCommand = new DelegateCommand<string>((Number) =>
            {
                try
                {
                    Model.Numbers.Add(Convert.ToInt32(Number));
                }
                catch (Exception) { }
            });

            RemoveCommand = new DelegateCommand<int?>(
                (Number) =>
                {
                    if (Number.HasValue)
                        Model.Numbers.RemoveAt(Number.Value);
                });
        }
    }
}
