using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DNS
{
    public class DNSRecord
    {
        public string? RecordType { get; set; }
        public string? IpAdress { get; set; }
        public int Ttl { get; set; }
    }
}
