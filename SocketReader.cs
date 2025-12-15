using System;
using System.Net.Sockets;
using System.Text;

namespace HelloConnectedWorld.Shared
{
    public class SocketReader
    {
        Socket _clientSocket;
        public SocketReader(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }
        public string ReceiveString(int bufferSize = 1024)
        {
            try
            {
                byte[] msg = new byte[bufferSize];
                int received = _clientSocket.Receive(msg);
                if (received == 0)
                {
                    // remote closed connection
                    return null; // caller should detect null and close session
                }
                return Encoding.ASCII.GetString(msg, 0, received);
            }
            catch (SocketException)
            {
                // log if needed, treat as disconnected
                return null;
            }
        }

    }
}

    
