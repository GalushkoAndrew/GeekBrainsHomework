using System;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public class CallCenter
    {
        public async Task SendMessage(string message)
        {
            var timeWriting = (new Random()).Next(100, 400);
            await Task.Run(async () =>
                {
                    await Task.Delay(timeWriting);
                    Console.WriteLine(message);
                });
        }
    }
}
