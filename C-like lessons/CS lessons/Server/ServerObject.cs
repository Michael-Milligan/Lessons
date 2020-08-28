using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class ClientObject
    {
        internal NetworkStream _Stream;
        TcpClient _Client;
        ServerObject _Server;

            internal string _ID;
            string _UserName;

            public ClientObject(TcpClient Client, ServerObject Server)
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
                    _UserName = GetMessage()[..^1];
                    var Message = _UserName + " has entered the chat";
                    Console.WriteLine(Message);
                    _Server.BroadcastMessage($"\r{Message}\nYou: ", _ID);
                    while (true)
                    {
                        Message = $"\r{_UserName}: {GetMessage()}You: ";
                        _Server.BroadcastMessage(Message, _ID);
                    }
                }
                catch
                {
                    var Message = _UserName + " has left the chat";
                    Console.WriteLine(Message);
                    _Server.BroadcastMessage($"\r{Message}\nYou: ", _ID);
                }
                finally
                {
                    _Server.RemoveConnection(_ID);
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
                Message.Append("\n");
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
        internal TcpListener _Server;
        List<ClientObject> _Clients = new List<ClientObject>();

        public void AddConnection(ClientObject Client)
        {
            _Clients.Add(Client);
        }

        public void RemoveConnection(string ID)
        {
            try { _Clients.Remove(_Clients.FirstOrDefault(item => item._ID == ID)); }
            catch (Exception) { }

        }

        public void BroadcastMessage(string Message, string ID)
        {
            foreach (var Client in _Clients.Where(Client => Client._ID != ID))
            {
                Client._Stream.Write(Encoding.UTF8.GetBytes(Message, 0, Message.Length));
            }
        }

        public void Disconnect()
        {
            foreach (var Client in _Clients)
            {
                Client.Close();
            }

            _Server.Stop();

            Environment.Exit(0);

        }

        public void Listen()
        {
            _Server = new TcpListener(IPAddress.Any, 8888);

            try
            {
                Console.WriteLine("Waiting for connections...");
                Console.WriteLine("The connection dates and messages:");
                _Server.Start(10);

                while (true)
                {
                    TcpClient Client = _Server.AcceptTcpClient();
                    ClientObject Object = new ClientObject(Client, this);
                    Thread NewThread = new Thread(Object.Process);
                    NewThread.Start();
                }
            }
            catch (SocketException Exception)
            {
                Console.WriteLine($"The error: {Exception.Message}\nThe Stacktrace: {Exception.StackTrace}\nThe code of error: {Exception.SocketErrorCode}");
                Disconnect();
            }
        }
    }
}
