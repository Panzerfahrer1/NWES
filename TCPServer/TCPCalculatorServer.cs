using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    public class TCPCalculatorServer : ITCPServerInterface
    {
        private TcpListener server;

        public TCPCalculatorServer(IPAddress address, int port)
        {
            if (address == null || port < 0)
            {
                throw new ArgumentException();
            }
            server = new TcpListener(address, port);
        }

        public void Start()
        {
            server.Start();

            while (true)
            {
                using TcpClient client = server.AcceptTcpClient();
                using NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[4096];

                int bytesRead = 0;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string Message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine(Message);

                    byte[] resp = Encoding.UTF8.GetBytes("OK\n");
                    stream.Write(resp, 0, resp.Length);
                }
            }
        }

    }
}