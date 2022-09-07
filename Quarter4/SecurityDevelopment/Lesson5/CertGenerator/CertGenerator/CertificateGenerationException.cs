using System;

namespace CertGenerator
{
    public class CertificateGenerationException : Exception
    {
        public CertificateGenerationException(string message)
            : base(message)
        {

        }
    }
}
