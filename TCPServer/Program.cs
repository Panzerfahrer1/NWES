
using TCPServer;

tcpServer server = new tcpServer(8080, System.Net.IPAddress.Loopback);

server.Start();