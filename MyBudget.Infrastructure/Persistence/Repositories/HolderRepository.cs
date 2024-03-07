using Microsoft.EntityFrameworkCore;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class HolderRepository : GenericRepository<Holder>
{
    public HolderRepository(DbContext context): base(context)
    {   
    }
    
    public new Holder? GetById(Guid id)
    {
        return GetByIdQuery(id).SingleOrDefault();
    }

    public new async Task<Holder?> GetByIdAsync(Guid id)
    {
        return await GetByIdQuery(id).SingleOrDefaultAsync();
    }
    
    private IQueryable<Holder> GetByIdQuery(Guid id)
    {
        return dbSet
            .Include(x => x.Accounts)
            .Where(x => x.Id == id);
    }
}
