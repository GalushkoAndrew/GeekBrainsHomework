using PumpClient.PumpServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PumpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
            PumpnServiceClient client = new PumpnServiceClient(instanceContext);

            client.UpdateAndCompileScript(@"C:\scripts\Sample.script");
            client.RunScript();

            Console.WriteLine("Please, Enter to exit ...");
            Console.ReadKey(true);
            client.Close();
        }
    }
}
