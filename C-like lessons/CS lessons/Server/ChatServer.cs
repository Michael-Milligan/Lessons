using System;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class ChatServer
    {
        static ServerObject Server;
        static Thread ListenThread;
        static void Main()
        {
            try
            {
                Server = new ServerObject();
                ListenThread = new Thread(Server.Listen);
                ListenThread.Start();
            }
            catch (SocketException Exception)
            {
                Server.Disconnect();
                Console.WriteLine($"The error: {Exception.Message}\nThe Stacktrace: {Exception.StackTrace}\nThe code of socket error: {Exception.SocketErrorCode}");
            }

        }
    }
}
