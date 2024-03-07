using Microsoft.EntityFrameworkCore;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class AccountRepository : GenericRepository<Account>
{
    public AccountRepository(DbContext context): base(context)
    {   
    }
    
    public new Account? GetById(Guid id)
    {
        return GetByIdQuery(id).SingleOrDefault();
    }

    public new async Task<Account?> GetByIdAsync(Guid id)
    {
        return await GetByIdQuery(id).SingleOrDefaultAsync();
    }
    
    private IQueryable<Account> GetByIdQuery(Guid id)
    {
        return dbSet
            .Include(x => x.Currency)
            .Include(x => x.Keeper)
            .Include(x => x.Holder)
            .Include(x => x.LinkedAccount)
            .Include(x => x.Parent)
            .Include(x => x.Children)
            .ThenInclude(x => x.Children)
            .Where(x => x.Id == id);
    }
}
