using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class AccountTypeRepository
    : Repository<AccountType>,
        IAccountTypeRepository
{
    public AccountTypeRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public IQueryable<AccountType> QueryRich()
    {
        return dbSet
            .Include(x => x.AncestorAccountTypeLinks)
            .ThenInclude(x => x.Child);
    }
}
