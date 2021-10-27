using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PhoneBookManager
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var configuration = GetConfiguration();

            try
            {
                var host = BuildWebHost(configuration, args);

                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
         .CaptureStartupErrors(false)
         .UseStartup<Startup>()
         .UseContentRoot(Directory.GetCurrentDirectory());

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .CaptureStartupErrors(false)
              .UseStartup<Startup>()
              .UseConfiguration(configuration)
              .Build();

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
