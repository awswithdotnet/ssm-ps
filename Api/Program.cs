using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(
                c => {
                    c.AddSystemsManager(source =>{
                        source.Path = "/testapp";
                        source.ReloadAfter = TimeSpan.FromMinutes(10);
                    });
                }
            )
            .ConfigureWebHostDefaults(webBuilder =>
            {
                    webBuilder.UseStartup<Startup>();

            });
    }
}