using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);

            await _next(context);

            await LogResponse(context);
        }

        private Task LogRequest(HttpContext context)
        {
            var a = context.Request.Protocol;
            if (context.Request.ContentType == "application/grpc")
            {
                return Task.CompletedTask;
            }
            
            try
            {
                context.Request.EnableBuffering();
                
                StringBuilder headers = new ();
                headers.AppendJoin(", ", context.Request.Headers.Values);
                
                string fullRequestPath = context.Request.PathBase + context.Request.Path;
                
                _logger.LogInformation("Request logged");
                _logger.LogInformation("Headers: {headers}", headers.ToString());
                _logger.LogInformation("Route: {route}", fullRequestPath);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
            
            return Task.CompletedTask;
        }

        private Task LogResponse(HttpContext context)
        {
            if (context.Response.ContentType == "application/grpc")
            {
                return Task.CompletedTask;
            }

            var a = context.Request.Protocol;
            try
            {
                StringBuilder headers = new ();
                headers.AppendJoin(", ", context.Response.Headers.Values);
                
                _logger.LogInformation("Response logged");
                _logger.LogInformation("Headers: {headers}", headers.ToString());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response body");
            }
            
            return Task.CompletedTask;
        }
    }
}