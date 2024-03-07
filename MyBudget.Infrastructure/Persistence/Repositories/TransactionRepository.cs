using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Domain;

namespace MyBudget.Infrastructure.Persistence.Repositories;

public class TransactionRepository : GenericRepository<Transaction>
{
    public TransactionRepository(DbContext context): base(context)
    {   
    }

    public new IEnumerable<Transaction> GetAll()
    {
        return GetAllQuery();
    }

    public new async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await GetAllQuery().ToListAsync();
    }
    
    private IQueryable<Transaction> GetByIdQuery(Guid id)
    {
        return dbSet
            .Include(x => x.TransactionItems)
            .ThenInclude(x => x.Account)
            .ThenInclude(x => x.Currency)
            .Where(x => x.Id == id);
    }
    
    private IQueryable<Transaction> GetAllQuery()
    {
        return dbSet
            .Include(x => x.TransactionItems)
            .ThenInclude(x => x.Account);
    }
}
