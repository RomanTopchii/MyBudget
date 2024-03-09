using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class HolderRepository : Repository<Holder>, IHolderRepository
{
    public HolderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public new async Task<Holder?> GetByIdAsync(Guid id)
    {
        return await dbSet
            .Include(x => x.Accounts)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
    }
}
