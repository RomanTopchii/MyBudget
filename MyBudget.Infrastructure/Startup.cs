using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Infrastructure.Persistence;
using MyBudget.Infrastructure.Persistence.Repositories;

namespace MyBudget.Infrastructure;

public static class Startup
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(connectionString))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient(typeof(IRepository<>), typeof(Repository<>))
            .AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<ICurrencyRepository, CurrencyRepository>()
            .AddTransient<IHolderRepository, HolderRepository>()
            .AddTransient<IKeeperRepository, KeeperRepository>()
            .AddTransient<ITransactionRepository, TransactionRepository>();
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
