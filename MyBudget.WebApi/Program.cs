using MyBudget.WebApi;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationsServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration
        .MinimumLevel.Error()
        .WriteTo.MSSqlServer(connectionString, "Logs", autoCreateSqlTable: true);
});

var app = builder.Build();

MyBudget.Infrastructure.Startup.Configure(app.Services);

app.UseMiddleware<Middleware>();

app.UseFastEndpoints(c => { c.Endpoints.RoutePrefix = "api"; });

app.UseSwaggerGen();

app.Run();
