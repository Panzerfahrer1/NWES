using TCPClient;

tcpClient client = new tcpClient(8080, System.Net.IPAddress.Loopback);
client.SendMessage("Hello from TCP Client!");
Console.WriteLine(client.GetMessage()); 
System.Threading.Thread.Sleep(1000);
client.SendMessage("Goodbye from TCP Client!");
Console.WriteLine(client.GetMessage());
client.SendMessage("Goodbye from TCP Client!");
Console.WriteLine(client.GetMessage());
client.SendMessage("Goodbye from TCP Client!");
Console.WriteLine(client.GetMessage());
client.SendMessage("Goodbye from TCP Client!");
client.SendMessage("Goodbye from TCP Client!");
Console.WriteLine(client.GetMessage());
Console.WriteLine(client.GetMessage());