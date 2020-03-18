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
    TextBox[] Boxes;


    [STAThread]
    static void Main()
    {
        new Application().Run(new Program());
    }

    public Program()
    {
        Title = "Some Title";
        SizeToContent = SizeToContent.Height;
        Width = 300;

        StackPanel Panel = new StackPanel();
        Panel.VerticalAlignment = VerticalAlignment.Stretch;
        Panel.Orientation = Orientation.Vertical;
    
        //Initialisation of Grids
    
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

        //Adding the elements to first grid

        for (int i = 0; i < 5; ++i)
        {
            RowDefinition Row = new RowDefinition();
            Row.Height = new GridLength(20, GridUnitType.Star);
            FirstGrid.RowDefinitions.Add(Row);
            if (i < 2)
            {
                ColumnDefinition Column = new ColumnDefinition();
                Column.Width = new GridLength(50, GridUnitType.Star);
                FirstGrid.ColumnDefinitions.Add(Column);
            }
        }

        //Initializing the Boxes
        Boxes = new TextBox[5];
        for (int i = 0; i < Boxes.Length; i++)
        {
            Boxes[i] = new TextBox();
            Boxes[i].AcceptsReturn = true;
        }

        //Creating the string array
        string[] StringLabels = { "_First Name:", "_Last Name:", "_ID:", "_Credit Card Number:", "_Other Info" };

        //Creating the Labels
        for (int i = 0; i < StringLabels.Length; i++)
        {
            Label label = new Label();
            label.Content = StringLabels[i];
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;

            //Adding the label to first grid
            FirstGrid.Children.Add(label);
            Grid.SetRow(label, i);
            Grid.SetColumn(label, 0);
        }

        //Adding the Boxes to first grid
        for (int i = 0; i < Boxes.Length; ++i)
        {
            FirstGrid.Children.Add(Boxes[i]);
            Grid.SetRow(Boxes[i], i);
            Grid.SetColumn(Boxes[i], 1);
        }

        //Creating the Buttons
        Button OKButton = new Button();
        OKButton.Content = "_OK";
        OKButton.HorizontalAlignment = HorizontalAlignment.Center;
        OKButton.Click += (object Sender, RoutedEventArgs Args) => Close();

        Button CancelButton = new Button();
        CancelButton.Content = "_Cancel";
        CancelButton.HorizontalAlignment = HorizontalAlignment.Center;
        CancelButton.Click += (object Sender, RoutedEventArgs Args) => {
            MessageBoxResult Result = MessageBox.Show("Are you sure you want to exit?",
                                                        "Propmt",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes) Application.Current.MainWindow.Close();
        };

        //Adding columns to second grid
        SecondGrid.ColumnDefinitions.Add(new ColumnDefinition());
        SecondGrid.ColumnDefinitions.Add(new ColumnDefinition());


        //Adding the buttons to second grid
        SecondGrid.Children.Add(OKButton);
        Grid.SetRow(OKButton, 0);
        Grid.SetColumn(OKButton, 0);

        SecondGrid.Children.Add(CancelButton);
        Grid.SetRow(CancelButton, 0);
        Grid.SetColumn(CancelButton, 1);

        Content = Panel;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}


