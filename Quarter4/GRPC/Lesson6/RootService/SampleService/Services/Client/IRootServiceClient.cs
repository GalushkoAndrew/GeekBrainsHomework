using RootServiceNamespace;

namespace SampleService.Services.Client
{
    public interface IRootServiceClient
    {
        public RootServiceNamespace.RootServiceClient RootServiceClient { get; }
        public Task<IEnumerable<WeatherForecast>> Get();
    }
}
