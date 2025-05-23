namespace Arora.ApiRequestLogger.Services;
public class RouteLoggerOptions
{
    public string RouteLogPath { get; set; } = "logs/routes.txt";
    public string SummaryLogPath { get; set; } = "logs/summary.txt";
    public bool EnableDetailedLogging { get; set; } = true;
}