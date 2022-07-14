using Microsoft.Extensions.DependencyInjection;
using MvcFirstProject.Services;

namespace MvcFirstProject.DomainEvents.EventConsumers
{
    public class SkuAddedEmailSender : BackgroundService
    {
        private readonly ILogger<SkuAddedEmailSender> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SkuAddedEmailSender(ILogger<SkuAddedEmailSender> logger, IServiceScopeFactory serviceScopeFactory)
        {
            DomainEventsManager.Register<SkuAdded>((e) => _ = SendEmailNotification(e));
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        private async Task SendEmailNotification(SkuAdded e)
        {
            try {
                await using var scopeContainer = _serviceScopeFactory.CreateAsyncScope();
                var sendMailService = scopeContainer.ServiceProvider.GetRequiredService<ISendMailService>();
                await sendMailService.SendAsync("Notification", "New goods added", e.CancellationToken);
            }
            catch (Exception) {
                _logger.LogError("Ошибка при отправке почты");
                throw;
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
