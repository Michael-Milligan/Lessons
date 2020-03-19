using System;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;

class Program
{ 
    static void Main()
    {
        using (StreamWriter Writer = new StreamWriter("C:\\Users\\User\\Desktop\\1.txt", true, Encoding.UTF8))
        {
            Writer.WriteLine("Hello, Admin");
            Writer.Write("Hello, User");
        }
        using (StreamReader Reader = new StreamReader("C:\\Users\\User\\Desktop\\1.txt"))
        {
            MessageBox.Show(Reader.ReadToEnd(), "Info");
        }
    }
}
