using MyBudget.WebApi;
using MyBudget.WebApi.AutoRegistration;
using MyBudget.WebApi.Hangfire;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationsServices(builder.Configuration);

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning()
    .AddApiExplorer()
    .EnableApiVersionBinding();

builder.Services.RegisterHangfireServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    var sinkOptions = new MSSqlServerSinkOptions
    {
        AutoCreateSqlDatabase = true,
        AutoCreateSqlTable = true,
        TableName = "Log"
    };

    configuration
        .MinimumLevel.Error()
        .WriteTo.MSSqlServer(connectionString, sinkOptions);
});

var app = builder.Build();

MyBudget.Infrastructure.Startup.Configure(app.Services);

app.UseSession();
app.UseMiddleware<Middleware>();
app.RegisterApiRoutes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();

            foreach (var description in descriptions)
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
                // options.RoutePrefix = string.Empty;
            }
        });
}

app.RegisterHangfireDashboard();
app.RegisterHangfireJobs();

app.Run();
