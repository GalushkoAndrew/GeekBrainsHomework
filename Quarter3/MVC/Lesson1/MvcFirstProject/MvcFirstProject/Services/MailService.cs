using MailKit.Net.Smtp;
using MimeKit;
using MvcFirstProject.Models.Mail;

namespace MvcFirstProject.Services
{
    public sealed class MailKitSendMailService : ISendMailService
    {
        public void Send(MailFields mailFields)
        {
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(mailFields.From, mailFields.From));
            mimeMessage.To.Add(new MailboxAddress(mailFields.To, mailFields.To));
            mimeMessage.Subject = mailFields.Subject;

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = mailFields.Body
            };

            var client = new SmtpClient();
            client.Connect(mailFields.Host, mailFields.Port, false);
            client.Authenticate(mailFields.From, mailFields.Password);
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
