using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Extensions;

namespace OzonEdu.MerchandiseService
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
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        int.TryParse(Environment.GetEnvironmentVariable("OZON_EDU_GRPC_PORT"), out int port);
                        
                        webBuilder.ConfigureKestrel(options =>
                        {
                            options.ListenLocalhost(port,
                                o =>
                                    o.Protocols = HttpProtocols.Http2);
                        });
                    }

                    webBuilder.UseStartup<Startup>();
                })
                .AddInfrastructure()
                .AddHttp();
    }
}