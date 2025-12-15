using HelloConnectedWorld.Server.Contracts;
using System;
using System.Net.Sockets;

namespace HelloConnectedWorld.Server
{
    public class ClientHandler
    {
        Socket _serverSocket;
        Session _session;
        IServiceLogger _logger;
        public ClientHandler(Socket serverSocket, IServiceLogger logger)
        {
            _serverSocket = serverSocket;
            _logger = logger;   
        }

        public void AcceptClients()
        {
            while (true)
            {
                _logger.LogSystemInformation("waiting for connection request ...");
                Socket clientSocket = _serverSocket.Accept();
                _logger.LogSystemInformation("client connected: " + clientSocket.RemoteEndPoint);
                _session = new Session(clientSocket, _logger);
                _session.HandleCommunication();         
            }
        }
    }
}
