using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lessons
{
    class Program
    {
        public static int Port = 8005;
        public static string IP = "127.0.0.1";
        /*Server Part*/
        //static void Main(string[] args)
        //{
        //    Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    var LocalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
        //    Console.WriteLine("Listening...");
        //    try
        //    {
        //        ListenSocket.Bind(LocalEndPoint);
        //        ListenSocket.Listen(10);

        //        while (true)
        //        {
        //            while (true)
        //            {
        //                Socket handler = ListenSocket.Accept();
        //                // получаем сообщение
        //                StringBuilder builder = new StringBuilder();
        //                int bytes = 0; // количество полученных байтов
        //                byte[] data = new byte[256]; // буфер для получаемых данных

        //                do
        //                {
        //                    bytes = handler.Receive(data);
        //                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //                }
        //                while (handler.Available > 0);

        //                Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

        //                // отправляем ответ
        //                string message = "ваше сообщение доставлено";
        //                data = Encoding.Unicode.GetBytes(message);
        //                handler.Send(data);
        //                // закрываем сокет
        //                handler.Shutdown(SocketShutdown.Both);
        //                handler.Close();
        //            }
        //        }
        //    }
        //    catch (Exception Exception)
        //    {
        //        Console.WriteLine($"{Exception.Message} \nline:{Exception.StackTrace}");
        //    }
        //    Console.ReadLine();
        //}

        /*Client Part*/
        //public static void Main()
        //{
        //    IPAddress ServerIP = IPAddress.Parse(IP);
        //    Socket ConnectionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    try
        //    {
        //        var EndPoint = new IPEndPoint(ServerIP, Port);
        //        ConnectionSocket.Connect(EndPoint);
        //        Console.WriteLine("Type your message:");
        //        ConnectionSocket.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));

        //        byte[] Buffer = new byte[1204];
        //        ConnectionSocket.Receive(Buffer);
        //        Console.WriteLine($"The server's answer: {Encoding.UTF8.GetString(Buffer)}");
        //    }
        //    catch (Exception Exception)
        //    {
        //        Console.WriteLine($"{Exception.Message} \nTrace: {Exception.StackTrace}");
        //    }


        //    ConnectionSocket.Shutdown(SocketShutdown.Both);
        //    ConnectionSocket.Close();
        //}
    }
}
