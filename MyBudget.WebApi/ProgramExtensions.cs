using FastEndpoints;
using FastEndpoints.Swagger;

namespace MyBudget.WebApi;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddFastEndpoints(o => o.IncludeAbstractValidators = true);
        services.SwaggerDocument();

        Application.Startup.ConfigureServices(services);
        new Infrastructure.Startup(configuration).Configure(services);
    }
}
