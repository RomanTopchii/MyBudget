using Microsoft.Extensions.Options;
using MyBudget.WebApi.Extensions;
using MyBudget.WebApi.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyBudget.WebApi;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddTransient<Middleware>();

        Application.Startup.ConfigureServices(services);
        Infrastructure.Startup.Configure(services, configuration.GetConnectionString("DefaultConnection"));
        
        services.AddCustomVersioning();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    }
}
