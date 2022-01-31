using System;
using System.Net.Http;
using GeekBrains.Learn.Core.DAO.Model;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Register manager
    /// </summary>
    public class RegisterManager : IRegisterManager
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly StartOptions _startOptions;

        /// <inheritdoc/>
        public RegisterManager(IHttpClientFactory httpClientFactory, StartOptions startOptions)
        {
            _clientFactory = httpClientFactory;
            _startOptions = startOptions;
        }

        /// <inheritdoc/>
        public bool Register()
        {
            var client = _clientFactory.CreateClient("Agent");

            string currentUri = _startOptions.LocalUri;
            string managerUri = _startOptions.ManagerUri;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{managerUri}/MetricsManager/register?uri={currentUri}");

            try
            {
                var response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
