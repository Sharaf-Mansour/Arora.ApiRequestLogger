
# Arora.ApiRequestLogger
A lightweight, pluggable middleware to **log every API call** and track which routes are used the most. Built for .NET 8+.

---

## Features

- ✅ Logs every HTTP request route and method
- ✅ Tracks route usage count
- ✅ Dumps summary to a file on shutdown or manually
- ✅ Fully customizable paths & logging behavior
- ✅ Zero dependencies. Minimal performance impact.

---

## Installation

```bash
dotnet add package Arora.ApiRequestLogger
```

---

## Usage

### 1. Add Middleware

```csharp
app.UseRequestLogger(new RouteLoggerOptions
{
    RouteLogPath = "logs/routes.txt",
    SummaryLogPath = "logs/summary.txt",
    EnableDetailedLogging = true
});
```

### 2. Dump Usage on App Shutdown

```csharp
app.Lifetime.ApplicationStopping.Register(() =>
{
    RequestLoggingMiddleware.DumpUsageSummary(new RouteLoggerOptions
    {
        SummaryLogPath = "logs/summary.txt"
    });
});
```

---

## Configuration: `RouteLoggerOptions`

| Property             | Type    | Default Value        | Description                              |
|----------------------|---------|-----------------------|------------------------------------------|
| `RouteLogPath`       | string  | `"logs/routes.txt"`   | Path to save detailed route logs         |
| `SummaryLogPath`     | string  | `"logs/summary.txt"`  | Path to dump route usage summary         |
| `EnableDetailedLogging` | bool | `true`               | Turn on/off per-request logging          |

---

## Output

- **routes.txt**  
  Logs each request with timestamp  
  ```
  2025-05-23 14:33:01: GET /api/products
  2025-05-23 14:33:02: POST /api/login
  ```

- **summary.txt**  
  Shows how many times each route was called  
  ```
  GET /api/products -> 19
  POST /api/login -> 7
  ```

---

## License

MIT License – use it, remix it, Have fun ☺ 
**BUILT WITH ♥**