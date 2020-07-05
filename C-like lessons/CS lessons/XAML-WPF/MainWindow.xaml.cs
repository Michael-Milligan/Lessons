using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XAML_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random(DateTime.Now.Millisecond);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Answer.Content = (Answers)random.Next(0,2);
        }
        enum Answers
        {
            Yes,
            No
        }
    }
}
