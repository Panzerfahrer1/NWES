using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Calculator
{
    internal class Client
    {
        TcpClient client;
        NetworkStream stream;

        public Client(int port, IPAddress address)
        {
            client = new TcpClient(address.ToString(), port);
            stream = client.GetStream();
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
        }

        public string GetMessage()
        {
            byte[] buffer = new byte[1024];

            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            if (bytesRead == 0)
            {
                return string.Empty;
            }
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }
    }
}
