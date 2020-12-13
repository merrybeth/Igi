using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
    //using NLog.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Logging;


using ILogger = Serilog.ILogger;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                   
                    var config = services.GetRequiredService<IConfiguration>();
                    
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.File(config["all-logs"])
                        .WriteTo.Logger(lc => lc
                            .Filter.ByIncludingOnly(le => le.Level == LogEventLevel.Error)
                            .WriteTo.File(config["error-logs"]))
                        .WriteTo.Logger(lc => lc
                            .WriteTo.Console())
                        .CreateLogger();
                    
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).UseSerilog().ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}