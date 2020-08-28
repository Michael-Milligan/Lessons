using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Client
    {
        static string _UserName;
        static int _Port = 8888;
        static string _IP = "127.0.0.1";
        static NetworkStream _Stream;
        static TcpClient _Client;

        static void Main()
        {
            IPEndPoint LocalEndPoint = new IPEndPoint(IPAddress.Parse(_IP), _Port);

            _Client = new TcpClient();
            Console.Write("Type your name here: ");
            _UserName = Console.ReadLine();
            try
            {
                _Client.Connect(LocalEndPoint);
                _Stream = _Client.GetStream();
                NetworkStream Stream = _Client.GetStream();
                _Stream.Write(Encoding.UTF8.GetBytes(_UserName));

                Thread ReceiveThread = new Thread(ReceiveMessages);
                ReceiveThread.Start();
                Console.WriteLine($"Welcome, {_UserName}");
                SendMessages();
            }
            catch(SocketException Exception)
            {
                Console.WriteLine("The connection is lost.");
            }
            finally
            {
                if (_Client != null) _Client.Close();
            }
            Console.ReadLine();
        }

        public static void Disconnect()
        {
            if (_Stream != null)
                _Stream.Close();//отключение потока
            if (_Client != null)
                _Client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }

        public static void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    byte[] Buffer = new byte[1024];
                    StringBuilder Message = new StringBuilder();
                    do
                    {
                        int Length = _Stream.Read(Buffer, 0, Buffer.Length);
                        Message.Append(Encoding.UTF8.GetString(Buffer, 0, Length));
                    }
                    while (_Stream.DataAvailable);
                    Console.Write(Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("The connection is lost.");
                    Console.ReadLine();
                    Disconnect();
                }
            }
            
        }

        public static void SendMessages()
        {
            Console.WriteLine("\nEnter your message: ");
            while (true)
            {
                Console.Write("\rYou: ");
                byte[] Buffer = new byte[1024];
                Buffer = Encoding.UTF8.GetBytes(Console.ReadLine());
                _Stream.Write(Buffer);

            }
        }
    }
}
