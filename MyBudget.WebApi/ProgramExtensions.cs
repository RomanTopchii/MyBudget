namespace MyBudget.WebApi;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.AddTransient<Middleware>();

        Application.Startup.ConfigureServices(services);
        Infrastructure.Startup.Configure(services, configurationManager.GetConnectionString("DefaultConnection"));
    }
}
