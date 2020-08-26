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
            Socket ConnectionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ConnectionSocket.Connect(LocalEndPoint);

            byte[] Buffer = new byte[1024];
            Console.WriteLine("Enter your message: ");

            Buffer = Encoding.UTF8.GetBytes(Console.ReadLine());
            StringBuilder Message = new StringBuilder();

            ConnectionSocket.Send(Buffer);
            Buffer = new byte[1024];

            do
            {
                ConnectionSocket.Receive(Buffer);
                Buffer = Buffer.Where(item => item != 0).ToArray();
                Message.Append(Encoding.UTF8.GetString(Buffer));
            }
            while (ConnectionSocket.Available > 0);
            Console.WriteLine(Message);

            ConnectionSocket.Shutdown(SocketShutdown.Both);
            ConnectionSocket.Close();
            Console.ReadLine();
        }
    }
}
