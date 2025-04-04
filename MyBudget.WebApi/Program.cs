using MyBudget.WebApi;
using MyBudget.WebApi.Hangfire;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationsServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterHangfireServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((_, _, configuration) =>
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

app.UseMiddleware<Middleware>();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
//app.UseAuthorization();
app.MapControllers();

app.RegisterHangfireDashboard();
app.RegisterHangfireJobs();

app.Run();
