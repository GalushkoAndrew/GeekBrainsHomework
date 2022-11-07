using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PumpService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PumpService : IPumpService
    {
    }
}
