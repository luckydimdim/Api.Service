using System.IO;
using Microsoft.AspNetCore.Hosting;
using Cmas.Infrastructure.ServicesStartup;

namespace cmas.backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<ServicesStartup>()
                .Build();

            host.Run();
        }
    }
}