using ClinicService.Utils;

namespace AccountSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = PasswordUtils.CreatePasswordHash("12345");
            Console.WriteLine(result.passwordSalt);
            Console.WriteLine(result.passwordHash);
            Console.ReadKey();
        }
    }
}