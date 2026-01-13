using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    internal class tcpServer : ITCPServerInterface
    {
        private TcpListener server;

        public tcpServer(int port, IPAddress serverAdress)
        {
            server = new TcpListener(serverAdress, port);
        }

        public void Start()
        {
            try
            {
                server.Start();
                while (true)
                {
                    using TcpClient client = server.AcceptTcpClient();
                    using NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[1024];
                    int n;

                    while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string msg = Encoding.UTF8.GetString(buffer, 0, n);
                        Console.WriteLine("Received: " + msg);

                        byte[] resp = Encoding.UTF8.GetBytes("OK\n");
                        stream.Write(resp, 0, resp.Length);
                    }
                }
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

        private string ReadData(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            StringBuilder data = new StringBuilder();
            int bytesRead;
            do
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                data.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (stream.DataAvailable);

            return data.ToString();
        }
    }
}