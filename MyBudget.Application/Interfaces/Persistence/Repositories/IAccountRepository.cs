using MyBudget.Domain;

namespace MyBudget.Application.Interfaces.Persistence.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    IQueryable<Account> QueryRich();
    Task<Account?> GetRichByIdAsync(Guid id);
}