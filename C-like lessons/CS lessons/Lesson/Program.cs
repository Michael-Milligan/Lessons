using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls.Primitives;

class Program : Window
{
    TextBox BeginText;
    TextBox EndText;
    Label Lifespan;

    [STAThread]
    static void Main()
    {
        new Application().Run(new Program());
    }

    public Program()
    {
        Title = "Some Title";
        MinWidth = 300;

        StackPanel Panel = new StackPanel();
    
        //Initialisation of Grids
    {
        Grid FirstGrid = new Grid()
        {
            Margin = new Thickness(5),
            ShowGridLines = true
        };
        Panel.Children.Add(FirstGrid);

        Grid SecondGrid = new Grid
        {
            Margin = new Thickness(5),
            ShowGridLines = true
        };
        Panel.Children.Add(SecondGrid);
    }



        Content = Panel;
    }
}


