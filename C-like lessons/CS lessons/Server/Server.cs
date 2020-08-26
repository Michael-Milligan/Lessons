using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Server
    {
        static int Port = 8005;
        static string IP = "127.0.0.1";

        class ClientObject
        {
            public TcpClient Client;

            public ClientObject(TcpClient client)
            {
                Client = client ?? throw new ArgumentNullException(nameof(client));
            }

            public void Process()
            {
                NetworkStream Stream = null;
                try
                {
                    while (true)
                    {
                        Stream = Client.GetStream();
                        StringBuilder Message = new StringBuilder();
                        byte[] Buffer = new byte[1024];

                        do
                        {
                            int Length = Stream.Read(Buffer);
                            Message.Append(Encoding.UTF8.GetString(Buffer, 0, Length));
                        }
                        while (Stream.DataAvailable);

                        DateTime Now = DateTime.Now;
                        Console.WriteLine($"{Now.Day}/{Now.Month}/{Now.Year} {Now.Hour}:{Now.Minute} {Now.Second}s| {Message}");
                        Stream.Write(Encoding.UTF8.GetBytes("Your message was delivered to server"));
                    }
                }
                catch (SocketException Exception)
                {
                    Console.WriteLine($"The error: {Exception.Message}\nThe Stacktrace: {Exception.StackTrace}\nThe code of error: {Exception.SocketErrorCode}");
                }
                finally
                {
                    if (Stream != null) Stream.Close();
                    if (Client != null) Client.Close();
                }
            }
        }

        static void Main()
        {
            IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);

            try
            {
                TcpListener Server = new TcpListener(LocalEndPoint);

                Console.WriteLine("Waiting for connections...");
                Console.WriteLine("The connection dates and messages:");
                Server.Start(10);

                while (true)
                {
                    TcpClient Client = Server.AcceptTcpClient();
                    ClientObject Object = new ClientObject(Client);
                    Thread NewThread = new Thread(Object.Process);
                    NewThread.Start();
                }
            }
            catch (SocketException Exception)
            {
                Console.WriteLine($"The error: {Exception.Message}\nThe Stacktrace: {Exception.StackTrace}\nThe code of error: {Exception.SocketErrorCode}");
            }
            finally
            {
                
            }
        }
    }
}
