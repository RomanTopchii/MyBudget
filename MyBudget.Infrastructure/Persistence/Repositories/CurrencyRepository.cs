using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class CurrencyRepository : GenericRepository<Currency>
{
    public CurrencyRepository(DbContext context): base(context)
    {   
    }
    
    public new Currency? GetById(Guid id)
    {
        return GetByIdQuery(id).SingleOrDefault();
    }

    public new async Task<Currency?> GetByIdAsync(Guid id)
    {
        return await GetByIdQuery(id).SingleOrDefaultAsync();
    }
    
    private IQueryable<Currency> GetByIdQuery(Guid id)
    {
        return dbSet
            .Include(x => x.Accounts)
            .Where(x => x.Id == id);
    }
}
