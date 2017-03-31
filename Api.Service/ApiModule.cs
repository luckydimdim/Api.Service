using Cmas.Infrastructure.ErrorHandler;
using Microsoft.Extensions.Logging;
using Nancy;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cmas.Services.Api
{
    public class ApiModule : NancyModule
    {
        private ILogger _logger;

        public class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public ApiModule(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ApiModule>();

            Get("/", async (parameters, obj) =>
            {
                return await Response.AsText("Api Module Is Alive!");
            });

            Get("token", (parameters, obj) =>
            {
                throw new InvalidTokenErrorException("The User had an invalid token.");
            });

            Get("unhandled", (parameters, obj) =>
            {
                throw new System.InvalidOperationException("An invalid operation exception.");
            });
        }
    }
}