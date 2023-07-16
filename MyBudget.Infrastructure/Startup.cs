using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Infrastructure.Persistence;

namespace MyBudget.Infrastructure;

public class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }

    public static void Configure(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedService = scope.ServiceProvider;
            var applicationDbContext = scopedService.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.Database.Migrate();
        }
    }
}