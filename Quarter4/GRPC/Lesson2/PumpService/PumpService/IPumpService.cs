using System.ServiceModel;

namespace PumpService
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPumpServiceCallback)]
    public interface IPumpService
    {
        [OperationContract]
        void RunScript();

        [OperationContract]
        void UpdateAndComoileScript(string fileName);
    }
}
