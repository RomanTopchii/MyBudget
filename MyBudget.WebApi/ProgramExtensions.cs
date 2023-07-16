namespace MyBudget.WebApi;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        new Infrastructure.Startup(configuration).Configure(services);
    }
}