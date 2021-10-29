using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version",
                    builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/ready",
                    builder => builder.Run(c => c.Response.WriteAsync("ready")));
                app.Map("/live",
                    builder => builder.Run(c => c.Response.WriteAsync("live")));
                app.UseMiddleware<RequestLoggingMiddleware>();
                next(app);
            };
        }
    }
}