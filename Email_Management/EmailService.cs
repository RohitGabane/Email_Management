using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;

namespace Email_Management
{
    public class EmailService
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
           this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rohit", smtpUsername));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var textPart = new TextPart("plain")
            {
                Text = body
            };

            var multipart = new Multipart("mixed");
            multipart.Add(textPart);
            message.Body = multipart;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                client.Authenticate(smtpUsername, smtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
