using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Emailer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging((hostingContext, config) => { config.ClearProviders(); });
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                    webBuilder.UseSetting("detailedErrors", "true");
                    webBuilder.CaptureStartupErrors(true);
                });
    }
}
