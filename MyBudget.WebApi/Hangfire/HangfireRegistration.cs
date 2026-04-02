using Hangfire;
using Hangfire.PostgreSql;

namespace MyBudget.WebApi.Hangfire;

public static class HangfireRegistration
{
    public static void AddHangfireServices(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        var connectionString = configurationManager.GetConnectionString("DefaultConnection");
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(connectionString)));
        services.AddHangfireServer();
        services.AddMvc();
    }

    public static void RegisterHangfireDashboard(this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHangfireDashboard();
        });
    }

    public static void RegisterHangfireJobs(this WebApplication app)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var hangfireSettings = new HangfireSettings();
        configuration.GetSection("Hangfire").Bind(hangfireSettings);
        JobList.AddOrUpdate(hangfireSettings.JobTimings);
    }
}
