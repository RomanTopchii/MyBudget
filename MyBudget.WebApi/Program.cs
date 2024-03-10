using MyBudget.WebApi;
using MyBudget.WebApi.AutoRegistration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationsServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName,
        Version = "v1" });
});


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
app.RegisterApiRoutes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
        $"{builder.Environment.ApplicationName} v1"));
}

app.Run();
