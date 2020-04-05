using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Shapes;

class Program : Window
{
    [STAThread]
    static void Main()
    {
        new Application().Run(new Program());
    }

    public Program()
    {
        Title = "Program";
        Grid grid = new Grid();

        for (int i = 0; i < 3; ++i)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                Button button = new Button();
                button.Content = "Row " + (i + 1) + " Column " + (j + 1);
                grid.Children.Add(button);
                Grid.SetRow(button, i);
                Grid.SetColumn(button, j);
            }
        }

        GridSplitter Splitter = new GridSplitter();
        grid.Children.Add(Splitter);
        Splitter.Width = 4;
        Grid.SetRow(Splitter, 0);
        Grid.SetColumn(Splitter, 1);
        Grid.SetRowSpan(Splitter, 3);
        Splitter.Margin = new Thickness(1);

        Splitter.HorizontalAlignment = HorizontalAlignment.Center;

        Content = grid;
    }
}


