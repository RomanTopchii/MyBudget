using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class AccountRepository
    : Repository<Account>,
        IAccountRepository
{
    public AccountRepository(ApplicationDbContext context)
        : base(context)
    {
    }
    
    public IQueryable<Account> QueryRich()
    {
        return dbSet
            .Include(x => x.Currency)
            .Include(x => x.Keeper)
            .Include(x => x.Holder)
            .Include(x => x.LinkedAccount)
            .Include(x => x.Parent)
            .Include(x => x.Children)
            .ThenInclude(x => x.Children);
    }

    public async Task<Account?> GetRichByIdAsync(Guid id)
    {
        return await dbSet
            .Include(x => x.Currency)
            .Include(x => x.Keeper)
            .Include(x => x.Holder)
            .Include(x => x.LinkedAccount)
            .Include(x => x.Parent)
            .Include(x => x.Children)
            .ThenInclude(x => x.Children)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
    }
}
