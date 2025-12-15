using System;
using System.Net.Sockets;
using HelloConnectedWorld.Server.Contracts;
using HelloConnectedWorld.Shared;

namespace HelloConnectedWorld.Server
{
    public class Session
    {
        Socket _clientSocket;
        IServiceLogger _logger;

        public Session(Socket clientSocket, IServiceLogger logger)
        {
            _clientSocket = clientSocket;
            _logger = logger;
        }
        public void HandleCommunication()
        {
            string request = String.Empty,
                   response = String.Empty;

            SocketReader sr = new SocketReader(_clientSocket);
            SocketWriter sw = new SocketWriter(_clientSocket);
            while (true)
            {

                request = sr.ReceiveString();
                _logger.LogRequestInformation(request + " : request received from " + _clientSocket.RemoteEndPoint);
                if (request.ToLower()=="exit")
                {
                    break;
                }
                //create response
                response = new RequestHandler(request).GetResponse();
                sw.SendString(response);
                _logger.LogRequestInformation($"{response} sent to: {_clientSocket.RemoteEndPoint}");
            }

            Close();
        }
        private void Close()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }

    }
}
