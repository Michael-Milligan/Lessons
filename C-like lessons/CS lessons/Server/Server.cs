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

            TcpListener Server = new TcpListener(LocalEndPoint);

            Console.WriteLine("Waiting for connections...");
            Console.WriteLine("The connection dates and messages:");
            Server.Start(10);

            while (true)
            {
                TcpClient Handler = Server.AcceptTcpClient();
                NetworkStream Stream = Handler.GetStream();
                StringBuilder Message = new StringBuilder();
                byte[] Buffer = new byte[1024];

                do
                {
                    int Length = Stream.Read(Buffer);
                    Message.Append(Encoding.UTF8.GetString(Buffer, 0, Length));
                }
                while (Handler.Available > 0);

                DateTime Now = DateTime.Now;
                Console.WriteLine($"{Now.Day}/{Now.Month}/{Now.Year} {Now.Hour}:{Now.Minute} {Now.Second}s: {Message}");
                Stream.Write(Encoding.UTF8.GetBytes("Your message was delivered"));
                Handler.Dispose();
                Handler.Close();
            }
        }
    }
}
