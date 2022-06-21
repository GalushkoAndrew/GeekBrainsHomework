using MvcFirstProject.Models.Mail;

namespace MvcFirstProject.Services
{
    public interface ISendMailService
    {
        void Send(MailFields mailOptions);
    }
}
