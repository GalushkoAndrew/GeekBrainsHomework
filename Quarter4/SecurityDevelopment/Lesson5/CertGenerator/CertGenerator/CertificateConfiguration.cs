using System.Security.Cryptography.X509Certificates;

namespace CertGenerator
{
    public class CertificateConfiguration
    {
        public X509Certificate2 RootCertificate { get; set; }
        public int CertDuration { get; set; }
        public string CertName { get; set; }
        public string Password { get; set; }
        public string OutFolder { get; set; }
        public string Email { get; set; }
    }
}
