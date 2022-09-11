using Grpc.Net.Client;
using static ClientServiceProtos.ClientService;

namespace CardStorageClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создать клиента ...");
            Console.ReadLine();

            using (GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                ClientServiceClient client = new ClientServiceClient(channel);



                var response = client.Create(new ClientServiceProtos.CreateClientRequest
                {
                    FirstName = "Имя1",
                    Surname = "Фамилия1",
                    Patronymic = "Отчество1"
                });

                Console.WriteLine($"ClientId: {response.ClientId}; ErrCode: {response.ErrorCode}; ErrMessage: {response.ErrorMessage}");

            }  

        }
    }
}