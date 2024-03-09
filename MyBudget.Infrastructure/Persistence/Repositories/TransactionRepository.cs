using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public new async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await dbSet
            .Include(x => x.TransactionItems)
            .ThenInclude(x => x.Account)
            .ToListAsync();
    }
}
