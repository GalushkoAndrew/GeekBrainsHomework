using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerator
{
    public class X509Certificate2Wrapper
    {
        private X509Certificate2 cert = null;
        private string group = null;
        private string certGroupName = null;

        public X509Certificate2Wrapper(X509Certificate2 cert, string certGroupName, string group)
        {
            this.cert = cert;
            this.certGroupName = certGroupName;
            this.group = group;
        }

        public X509Certificate2 Certificate
        {
            get { return cert; }
        }

        public string PublishedFor
        {
            get { return cert.GetNameInfo(X509NameType.SimpleName, false); }
        }

        public string Published
        {
            get { return cert.GetNameInfo(X509NameType.SimpleName, true); }
        }


        public string ExpirationDate
        {
            get { return cert.GetExpirationDateString(); }
        }

        public string Group
        {
            get { return group; }
        }

        public string CertGroupName
        {
            get { return certGroupName; }
        }

        public override string ToString()
        {
            return $"Group: {Group} ({CertGroupName})\nPublishedFor: {PublishedFor}\nPublished: {Published}\nExp: {ExpirationDate}\n";
        }
    }
}
