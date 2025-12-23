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
                while (true)
                {
                    server.Start();

                    using TcpClient client = server.AcceptTcpClient();
                    using NetworkStream stream = client.GetStream();

                    string message = ReadData(stream);

                    Console.WriteLine(message);
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
