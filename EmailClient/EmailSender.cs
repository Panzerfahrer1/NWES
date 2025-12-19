using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailClient
{
    public class EmailSender
    {
        private SmtpServer smtpServer;
        private MailMessage mailMessage;

        /// <summary>
        /// Initializes a new instance of the EmailSender class with the specified sender and receiver addresses and
        /// SMTP server.
        /// </summary>
        /// <param name="senderAddress">The email address that will be used as the sender of outgoing messages. Cannot be null or empty.</param>
        /// <param name="recieverAdress">The email address that will receive the messages. Cannot be null or empty.</param>
        /// <param name="smtpServer">The SMTP server used to send email messages. Cannot be null.</param>
        public EmailSender(string senderAddress, string recieverAdress, SmtpServer smtpServer)
        {
            this.smtpServer = smtpServer;

            mailMessage = new MailMessage(senderAddress, recieverAdress);
        }

        /// <summary>
        /// Defines the subject and body of the email and sends it
        /// </summary>
        /// <param name="subject">subject line of the Email</param>
        /// <param name="body">message of the email</param>
        public void SetEmail(string subject, string body)
        {
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SendEmail();
        }

        /// <summary>
        /// This method sends the email using the SMTP server defined in the constructor.
        /// </summary>
        private void SendEmail()
        {
            using (SmtpClient smtpClient = new SmtpClient(smtpServer.ServerAddress, smtpServer.Port))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = smtpServer.NetworkCredential;
                smtpClient.EnableSsl = smtpServer.UseSsl;
                smtpClient.Send(mailMessage);
            }
        }
    }
}