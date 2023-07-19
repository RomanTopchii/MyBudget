using Microsoft.Extensions.DependencyInjection;

namespace MyBudget.Application;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
    }
}
