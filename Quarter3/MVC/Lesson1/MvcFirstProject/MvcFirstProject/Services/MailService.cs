using MailKit.Net.Smtp;
using MimeKit;
using MvcFirstProject.Models.Mail;

namespace MvcFirstProject.Services
{
    public sealed class SendMailService : ISendMailService
    {
        public void Send(MailFields mailFields)
        {
            using (var client = new SmtpClient()) {
                client.Connect(mailFields.Host, mailFields.Port, false);
                client.Authenticate(mailFields.From, mailFields.Password);
                var message = new MimeMessage(mailFields.From, mailFields.To, mailFields.Subject, mailFields.Body);
                client.Send(message);
            }
        }
    }
}
