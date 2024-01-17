using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace Email_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "rohitgabane1234@gmail.com";
            string smtpPassword = "fzir fvrv rjnf xtzq";

            var emailService = new EmailService(smtpServer, smtpPort, smtpUsername, smtpPassword);

            string toEmail = "grohit0923@gmail.com"; //recepient email
            string subject = "Task Completion Email!!!!!!!!!!!!!!!";
            string body = "Ronny is here......Gud Morning Sir!!!!!!!!!!!";

            emailService.SendEmail(toEmail, subject, body);
            Console.WriteLine("Email sent successfully!");
        }
    }
}
