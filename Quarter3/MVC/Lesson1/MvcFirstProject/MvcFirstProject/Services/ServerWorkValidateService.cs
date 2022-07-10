namespace MvcFirstProject.Services
{
    public class ServerWorkValidateService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private CancellationToken _stoppingToken = default;

        public ServerWorkValidateService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _ = SendEmailAlive();
        }

        private async Task SendEmailAlive()
        {
            await using var scopeContainer = _serviceScopeFactory.CreateAsyncScope();
            var sendMailService = scopeContainer.ServiceProvider.GetRequiredService<ISendMailService>();
            using var timer = new PeriodicTimer(TimeSpan.FromHours(1));
            await SendMailAsync(sendMailService, _stoppingToken);
            while (await timer.WaitForNextTickAsync(_stoppingToken)) {
                await SendMailAsync(sendMailService, _stoppingToken);
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _stoppingToken = stoppingToken;
            return Task.CompletedTask;
        }

        Task SendMailAsync(ISendMailService sendMailService, CancellationToken stoppingToken)
        {
            return sendMailService.SendAsync("Сервер жив", "Я, сервер, уведомляю, что жив.", stoppingToken);
        }
    }
}
