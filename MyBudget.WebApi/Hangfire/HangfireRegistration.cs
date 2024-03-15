using Hangfire;

namespace MyBudget.WebApi.Hangfire;

public static class HangfireRegistration
{
    public static void RegisterHangfireServices(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configurationManager.GetConnectionString("HangfireConnection")));
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
