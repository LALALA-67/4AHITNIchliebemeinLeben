using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HelloConnectedWorld.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            new TCPService(4711, new ConsoleLogger()).Start();

            Console.WriteLine("press enter to exit...");
            Console.ReadLine();
        }
    }
}
