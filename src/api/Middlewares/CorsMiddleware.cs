namespace api.Middlewares;

public class CorsMiddleware : IMiddleware
{
    private readonly ILogger<CorsMiddleware> _logger;

    public CorsMiddleware(ILogger<CorsMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogCritical("Cors applied");
        context.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:8000";
        await next(context);
    }
}
