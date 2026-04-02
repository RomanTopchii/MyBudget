using MyBudget.WebApi;
using MyBudget.WebApi.Hangfire;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);

var app = builder.Build();
ConfigureMiddleware(app);
ConfigureHangfire(app);
app.Run();


static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.RegisterApplicationsServices(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHangfireServices(builder.Configuration);
}

static void ConfigureMiddleware(WebApplication app)
{
    MyBudget.Infrastructure.Startup.Configure(app.Services);
    app.UseMiddleware<Middleware>();

    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    // app.UseAuthorization();
    app.MapControllers();
}

static void ConfigureHangfire(WebApplication app)
{
    app.RegisterHangfireDashboard();
    app.RegisterHangfireJobs();
}