using Grpc.Net.Client;
using static ClinicServiceProtos.ClinicClientService;

namespace ClinicClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("http://localhost:5001");


            ClinicClientServiceClient client = new ClinicClientServiceClient(channel);

            var createClientResponse = client.CreateClient(new ClinicServiceProtos.CreateClientRequest
            {
                Document = "PASS123",
                FirstName = "cтаниcлав",
                Surname = "Байраковcкий",
                Patronymic = "Антонович"
            });

            Console.WriteLine($"Client ({createClientResponse.ClientId}) created successfully.");

            var getClientsResponse = client.GetClients(new ClinicServiceProtos.GetClientsRequest());

            Console.WriteLine("Clients:");
            Console.WriteLine("========\n");
            foreach (var clientObj in getClientsResponse.Clients)
            {
                Console.WriteLine($"{clientObj.Document} >> {clientObj.Surname} {clientObj.FirstName}");
            }

            Console.ReadKey();
        }
    }
}