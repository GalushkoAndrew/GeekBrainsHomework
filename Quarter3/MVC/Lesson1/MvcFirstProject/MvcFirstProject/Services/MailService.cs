using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MvcFirstProject.Models.Mail;

namespace MvcFirstProject.Services
{
    public sealed class MailKitSendMailService : ISendMailService
    {
        private readonly IOptions<MailOptions> _mailOptions;
        private readonly string _login;
        private readonly string _password;

        public MailKitSendMailService(IOptions<MailOptions> mailOptions, IConfiguration config)
        {
            _mailOptions = mailOptions;
            _login = config["MailOptions:Login"];
            _password = config["MailOptions:Password"];
        }

        public void Send(string subj, string body)
        {
            var options = _mailOptions.Value;
            MimeMessage mimeMessage = GetMimeMessage(subj, body);

            var client = new SmtpClient();
            client.Connect(options.Host, options.Port, false);
            client.Authenticate(_login, _password);
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public async Task SendAsync(string subj, string body)
        {
            var options = _mailOptions.Value;
            MimeMessage mimeMessage = GetMimeMessage(subj, body);

            var client = new SmtpClient();
            await client.ConnectAsync(options.Host, options.Port, false);
            await client.AuthenticateAsync(_login, _password);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }

        private MimeMessage GetMimeMessage(string subj, string body)
        {
            var options = _mailOptions.Value;
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(_login, _login));
            mimeMessage.To.Add(new MailboxAddress(options.To, options.To));
            mimeMessage.Subject = subj;

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = body
            };
            return mimeMessage;
        }
    }
}
