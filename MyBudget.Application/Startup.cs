using Microsoft.Extensions.DependencyInjection;

namespace MyBudget.Application;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register MediatR services
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
    }
}