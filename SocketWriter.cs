using System;
using System.Net.Sockets;
using System.Text;

namespace HelloConnectedWorld.Shared
{
    public class SocketWriter
    {
        Socket _clientSocket;
        public SocketWriter(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public void SendString(string message)
        {
            // nachricht an client senden
            byte[] msg = Encoding.ASCII.GetBytes(message);
            _clientSocket.Send(msg);
        }
    }
}
