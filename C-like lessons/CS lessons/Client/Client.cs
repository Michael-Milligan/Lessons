using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client
    {
        static int Port = 8005;
        static string IP = "127.0.0.1";

        static void Main()
        {
            IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            TcpClient Client = new TcpClient();
            Client.Connect(LocalEndPoint);
            NetworkStream Stream = Client.GetStream();

            byte[] Buffer = new byte[1024];
            Console.WriteLine("Enter your message: ");

            Buffer = Encoding.UTF8.GetBytes(Console.ReadLine());
            StringBuilder Message = new StringBuilder();

            Stream.Write(Buffer);
            Buffer = new byte[1024];

            do
            {
                int Length = Stream.Read(Buffer, 0, Buffer.Length);
                Message.Append(Encoding.UTF8.GetString(Buffer, 0, Length));
            }
            while (Stream.DataAvailable);
            Console.WriteLine(Message);

            Stream.Dispose();
            Stream.Close();
            Console.ReadLine();
        }
    }
}
