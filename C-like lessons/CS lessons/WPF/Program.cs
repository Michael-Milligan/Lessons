using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Shapes;

class Program : Window
{
    static DispatcherTimer Timer = new DispatcherTimer();
    static Ellipse ellipse;

    [STAThread]
    static void Main()
    {
        new Application().Run(new Program());
    }

    public Program()
    {
        Button button = new Button();
        button.Content = "Press me!";
        button.HorizontalAlignment = HorizontalAlignment.Center;
        button.VerticalAlignment = VerticalAlignment.Center;
        button.Click += ButtonOnClick;

        RadialGradientBrush brush = new RadialGradientBrush(Colors.Red, Colors.Blue);
         ellipse = new Ellipse();
        ellipse.Height = ellipse.Width = 5;
        ellipse.Fill = brush;

        Timer.Interval = new TimeSpan(500000);
        Timer.Tick += TimerOnTick;

        Content = button;
    }

    void ButtonOnClick(object Sender, RoutedEventArgs Args)
    {
        Application.Current.MainWindow.Content = ellipse;
        Timer.Start();
    }

    void TimerOnTick(object Sender, EventArgs Args)
    {
        ellipse.Width = 1.05 * ellipse.Width;
        ellipse.Height = 1.05 * ellipse.Height;
    }
}


