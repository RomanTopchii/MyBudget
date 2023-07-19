using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class KeeperRepository : GenericRepository<Keeper>
{
    public KeeperRepository(DbContext context): base(context)
    {   
    }
    
    public new Keeper? GetById(Guid id)
    {
        return GetByIdQuery(id).SingleOrDefault();
    }

    public new async Task<Keeper?> GetByIdAsync(Guid id)
    {
        return await GetByIdQuery(id).SingleOrDefaultAsync();
    }
    
    private IQueryable<Keeper> GetByIdQuery(Guid id)
    {
        return dbSet
            .Include(x => x.Accounts)
            .Where(x => x.Id == id);
    }
}
