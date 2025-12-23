using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    internal class TCPServer
    {
        private TcpListener server;

        public TCPServer(int port, IPAddress serverAdress)
        {
            server = new TcpListener(serverAdress, port);
        }

        public void Start()
        {
            try
            {
                server.Start();
            }
            catch (SocketException ex)
            {
                throw new Exception("Could not start server", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while starting the server", ex);
            }
        }
    }
}
