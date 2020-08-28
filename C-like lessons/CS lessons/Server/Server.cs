using System;
using System.Collections.Generic;
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

        public class ClientObject
        {
            internal NetworkStream _Stream;
            TcpClient _Client;
            ServerObject _Server;

            internal string _ID;
            string _UserName;

            public ClientObject(TcpClient Client, ServerObject Server, string Name)
            {
                _Server = Server ?? throw new ArgumentNullException(nameof(Server));
                _Stream = Client.GetStream();
                _Client = Client ?? throw new ArgumentNullException(nameof(Client));
                _ID = Guid.NewGuid().ToString();
                _Server.AddConnection(this);
            }

            public void Process()
            {
                try
                {
                    _UserName = GetMessage();
                    var Message = _UserName + " has entered the chat";
                    _Server.BroadcastMessage(Message, _ID);
                    while (true)
                    {
                        Message = $"{_UserName}: {GetMessage()}";
                        _Server.BroadcastMessage(Message, _ID);
                    }
                }
                catch
                {
                    var Message = _UserName + " has left the chat";
                    Console.WriteLine(Message);
                    _Server.BroadcastMessage(Message, _ID);
                }
                finally
                {
                    Close();
                }
            }

            public string GetMessage()
            {
                StringBuilder Message = new StringBuilder();
                byte[] Buffer = new byte[1024];

                do
                {
                    int Length = _Stream.Read(Buffer);
                    Message.Append(Encoding.UTF8.GetString(Buffer, 0, Length));
                }
                while (_Stream.DataAvailable);
                return Message.ToString();
            }

            internal void Close()
            {
                if (_Stream != null)
                    _Stream.Close();
                if (_Client != null)
                    _Client.Close();
            }
        }

        public class ServerObject
        {
            internal NetworkStream _Stream;
            List<ClientObject> _Clients;

            public void AddConnection(ClientObject Client)
            {
                _Clients.Add(Client);
            }

            public void RemoveConnection(string ID)
            {
                _Clients.Remove(_Clients.FirstOrDefault(item => item._ID == ID));
            }

            public void BroadcastMessage(string Message, string ID)
            {

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
