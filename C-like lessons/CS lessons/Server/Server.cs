using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server
    {
        static int Port = 8005;
        static string IP = "127.0.0.1";

        static void Main()
        {
            IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);

            Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Waiting for connections...");
            Console.WriteLine("The connection dates and messages:");
            ListenSocket.Bind(LocalEndPoint);
            ListenSocket.Listen(10);

            while (true)
            {
                Socket Handler = ListenSocket.Accept();
                StringBuilder Message = new StringBuilder();
                byte[] Buffer = new byte[1024];

                do
                {
                    Handler.Receive(Buffer);
                    Buffer = Buffer.Where(item => item != 0).ToArray();
                    Message.Append(Encoding.UTF8.GetString(Buffer));
                }
                while (Handler.Available > 0);

                DateTime Now = DateTime.Now;
                Console.WriteLine($"{Now.Day}/{Now.Month}/{Now.Year} {Now.Hour}:{Now.Minute} {Now.Second}s: {Message}");
                Handler.Send(Encoding.UTF8.GetBytes("Your message was delivered"));
                Handler.Shutdown(SocketShutdown.Both);
                Handler.Close();
            }
            

        }
    }
}
