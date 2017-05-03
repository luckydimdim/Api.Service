using Microsoft.Extensions.Logging;
using Nancy;
using System.Threading;
using System.Threading.Tasks;

namespace Cmas.Services.Api
{
    public class ApiModule : NancyModule
    {
        private ApiService _apiService;

        public ApiModule(ILoggerFactory loggerFactory)
        {
            _apiService = new ApiService();

            Get<Response>("/", GetWelcomeMessageHandlerAsync);
        }

        #region Обработчики

        private async Task<Response> GetWelcomeMessageHandlerAsync(dynamic args, CancellationToken ct)
        {
            var result = _apiService.GetWelcomeMessage();

            return await Response.AsText(result);
        }

        #endregion
    }
}