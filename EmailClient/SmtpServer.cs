using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EmailClient
{
    public class SmtpServer
    {
        public string ServerAddress { get; private set; }
        public int Port { get; private set; }
        public bool UseSsl { get; private set; }
        public NetworkCredential NetworkCredential { get; private set; }
        public SmtpServer(string serverAddress = "mail.gmx.net", int port = 587, bool useSsl = true, string senderEmail = "info.oliver.weiss@gmx.at", string password = "SELLLLY7QKQNTU7WETFB")
        {
            ServerAddress = serverAddress;
            Port = port;
            UseSsl = useSsl;
            NetworkCredential = new NetworkCredential(senderEmail, password);
        }
    }
}
