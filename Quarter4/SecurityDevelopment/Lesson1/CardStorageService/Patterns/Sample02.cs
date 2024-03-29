﻿namespace Patterns
{
    public class GlobalSettings
    {
        public string Settings1 { get; set; }
        public string Settings2 { get; set; }
        public string Settings3 { get; set; }
    }

    internal class Sample02
    {
        static void Main(string[] args)
        {
            GlobalSettings settings = LazySingleton.Instance;

            var message = MailMessageBuilder
                .Create()
                .From("sample@gmail.com")
                .To("to_sample@gmail.com")
                .Subject("subject sample ...")
                .Body("body")
                .Build();
        }
    }

    public class LazySingleton
    {
        private static readonly Lazy<GlobalSettings> _instance = new Lazy<GlobalSettings>(() => new GlobalSettings(), true);

        public static GlobalSettings Instance
        {
            get { return _instance.Value; }
        }
    }

    public class MailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class MailMessageBuilder
    {
        private readonly MailMessage _mailMessage = new MailMessage();

        public static MailMessageBuilder Create()
        {
            return new MailMessageBuilder();
        }

        public MailMessage Build()
        {
            return _mailMessage;
        }

        public MailMessageBuilder From (string address)
        {
            _mailMessage.From = address;    
            return this;
        }

        public MailMessageBuilder To(string address)
        {
            _mailMessage.From = address;
            return this;
        }

        public MailMessageBuilder Subject(string subject)
        {
            _mailMessage.Subject = subject;
            return this;
        }

        public MailMessageBuilder Body(string body)
        {
            _mailMessage.Body = body;
            return this;
        }
    }
}

