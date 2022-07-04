namespace MvcFirstProject.Services
{
    public interface ISendMailService
    {
        void Send(string subj, string body);
    }
}
