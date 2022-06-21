namespace MvcFirstProject.Models.Mail
{
    public class MailFields
    {
        public MailFields(string from, string password, string to, string subject, string body, string host, int port)
        {
            From = from;
            Password = password;
            To = to;
            Subject = subject;
            Body = body;
            Host = host;
            Port = port;
        }

        public string To { get; }
        public string Subject { get; }
        public string Body { get; }
        public string Host { get; }
        public int Port { get; }
        public string From { get; }
        public string Password { get; }
    }
}
