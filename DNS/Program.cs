using DNS;
using DnsClient;
using DnsClient.Protocol;
using System.Net;

Console.WriteLine("Bitte geben sie einen Domain Namen ein:");
string domainName = "google.com";

var client = new LookupClient();

var resultV4 = client.Query(domainName, QueryType.ANY);

List<DNSRecord> records = new List<DNSRecord>();

foreach (var record in resultV4.Answers)
{
    DNSRecord dnsRecord = new DNSRecord();
    dnsRecord.RecordType = record.RecordType.ToString();
    dnsRecord.Ttl = (int)record.InitialTimeToLive;

    if (record is ARecord aRecord)
    {
        dnsRecord.IpAdress = aRecord.Address.ToString();
    } else if (record is AaaaRecord aaaaRecord)
    {
        dnsRecord.IpAdress = aaaaRecord.Address.ToString();
    } else if (record is NsRecord nsRecord)
    {
        dnsRecord.IpAdress = nsRecord.NSDName.ToString();
    }

    records.Add(dnsRecord);
}

foreach(var rec in records)
{
    Console.WriteLine($"Record Type: {rec.RecordType}, IP Address: {rec.IpAdress}, TTL: {rec.Ttl}");
    Console.WriteLine("----------------------------------------------------------------------------");
}

Console.WriteLine();