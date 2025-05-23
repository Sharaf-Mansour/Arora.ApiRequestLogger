using Microsoft.AspNetCore.Http;
using Arora.ApiRequestLogger.Services;
namespace Arora.ApiRequestLogger.Middleware;
public class RequestLoggingMiddleware(RequestDelegate next, RouteLoggerOptions options)
{
    private static readonly Dictionary<string, int> RouteCounter = [];
    private static readonly object Lock = new();
    public async Task InvokeAsync(HttpContext context)
    {
        var route = context.Request.Path.ToString();
        var method = context.Request.Method.ToString();
        var combined = $"{method} {route}";
        lock (Lock)
        {
            if (RouteCounter.ContainsKey(combined))
                RouteCounter[combined]++;
            else
                RouteCounter[combined] = 1;

            if (options.EnableDetailedLogging)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(options.RouteLogPath)!);
                File.AppendAllText(options.RouteLogPath, $"{DateTime.Now}: {combined}\n");
            }
        }
        await next(context);
    }
    public static void DumpUsageSummary(RouteLoggerOptions options)
    {
        lock (Lock)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(options.SummaryLogPath)!);
            File.WriteAllText(options.SummaryLogPath,
                string.Join("\n", RouteCounter.Select(kv => $"{kv.Key} -> {kv.Value}")));
        }
    }
}