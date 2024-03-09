using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public new async Task<Currency?> GetByIdAsync(Guid id)
    {
        return await dbSet
            .Include(x => x.Accounts)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
    }
}
