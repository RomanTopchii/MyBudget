using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Infrastructure.Persistence;

namespace MyBudget.Infrastructure;

public static class Startup
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(connectionString));
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
