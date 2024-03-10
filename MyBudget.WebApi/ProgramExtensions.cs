namespace MyBudget.WebApi;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddTransient<Middleware>();

        Application.Startup.ConfigureServices(services);
        Infrastructure.Startup.Configure(services, configuration.GetConnectionString("DefaultConnection"));
    }
}
