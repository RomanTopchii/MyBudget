using MyBudget.WebApi;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterApplicationsServices(builder.Configuration);

var app = builder.Build();

MyBudget.Infrastructure.Startup.Configure(app.Services);

app.UseFastEndpoints(c => { c.Endpoints.RoutePrefix = "api"; });

app.UseSwaggerGen();

app.Run();
