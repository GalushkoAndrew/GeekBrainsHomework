using ClinicServiceNamespace;
using Grpc.Net.Client;
using static ClinicServiceNamespace.ClinicService;

namespace ClinicClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient(channel);

            var createClientResponse = clinicServiceClient.CreateClinet(new CreateClientRequest
            {
                Document = "DOC34 445",
                FirstName = "Станислав",
                Patronymic = "Антонович",
                Surname = "Байраковский"
            });

            if (createClientResponse.ErrCode == 0)
            {
                Console.WriteLine($"Client #{createClientResponse.ClientId} created successfully.");
            }
            else
            {
                Console.WriteLine($"Create client error.\nErrorCode: {createClientResponse.ErrCode}\nErrorMessage: {createClientResponse.ErrMessage}");
            }

            var getClientResponse = clinicServiceClient.GetClients(new GetClientsRequest());

            if (createClientResponse.ErrCode == 0)
            {
                Console.WriteLine("Clients");
                Console.WriteLine("=======\n");

                foreach (var client in getClientResponse.Clients)
                {
                    Console.WriteLine($"#{client.ClientId} {client.Document} {client.Surname} {client.FirstName} {client.Patronymic}");
                }
            }
            else
            {
                Console.WriteLine($"Get clients error.\nErrorCode: {getClientResponse.ErrCode}\nErrorMessage: {getClientResponse.ErrMessage}");
            }

            Console.ReadKey();

        }
    }
}