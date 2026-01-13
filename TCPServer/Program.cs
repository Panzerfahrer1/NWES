
using System.Net;
using TCPServer;

TCPCalculatorServer TCPCalculatorServer = new(System.Net.IPAddress.Loopback, 1399);

Calculator.Validate("455+125-55/8");

//try
//{
//    TCPCalculatorServer.Start();
//}catch(Exception ex){
//    Console.WriteLine("Client Closed Connection");
//}
