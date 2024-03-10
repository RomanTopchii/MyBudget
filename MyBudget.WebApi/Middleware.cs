namespace MyBudget.WebApi;

public class Middleware : IMiddleware
{
    private readonly ILogger<Middleware> _logger;

    public Middleware(ILogger<Middleware> logger)
    {
        this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception?.Message);
            throw;
        }
    }
}
