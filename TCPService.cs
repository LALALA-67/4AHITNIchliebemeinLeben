using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HelloConnectedWorld.Server.Contracts;
using HelloConnectedWorld.Shared;

namespace HelloConnectedWorld.Server
{
    public class TCPService
    {
        #region fields
        IPEndPoint _endpoint;
        IPAddress _ipAddress;
        int _port;
        Socket serverSocket;
        ClientHandler _clientHandler;
        IServiceLogger _logger;

        #endregion

        #region constructor
        public TCPService(int port, IServiceLogger logger)
        {
            _port = port;
         
            _logger = logger;
            _ipAddress= IPAddress.Loopback;

            // network endpoint (IP Adresse und Port)
            _endpoint = new IPEndPoint(_ipAddress, _port);

            // instanz von Socket erzeugen
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp); // socket mit endpunkt verknüpfen
        }
        #endregion

        #region public methods

        public void Stop()
        {
            // ressourcen von clientSocket freigeben
            serverSocket.Close();
        }
        public void Start()
        {
            _logger.LogSystemInformation("starting service ...");
            serverSocket.Bind(_endpoint);
            // warten auf Verbindung
            serverSocket.Listen(20);
            _clientHandler = new ClientHandler(serverSocket, _logger);
            _clientHandler.AcceptClients();
        }
        #endregion
    }
}
