using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MvcImplicit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            string port = config["port"];
            IWebHostBuilder host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            if (!string.IsNullOrWhiteSpace(port))
            {
                host.UseUrls($"http://*:{port}");
            }
            return host;
        }
    }
}