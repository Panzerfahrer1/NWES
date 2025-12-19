using EmailClient;

string senderAddress = "info.oliver.weiss@gmx.at";
string reciverAdress = "info.oliver.weiss@gmx.at";

Console.WriteLine("Hello, World!");

SmtpServer smtpServer = new SmtpServer();
EmailSender emailSender = new EmailSender(senderAddress, reciverAdress, smtpServer);

emailSender.SetEmail("Test Email", "This is a test email sent from the EmailClient application.");