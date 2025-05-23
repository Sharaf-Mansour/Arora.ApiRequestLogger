using Arora.ApiRequestLogger.Middleware;
using Arora.ApiRequestLogger.Services;
namespace Microsoft.AspNetCore.Builder;
public static class RequestLoggerExtensions
{
    public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app, RouteLoggerOptions options)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>(options);
    }
}