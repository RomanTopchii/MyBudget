using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    IGenericRepository<Account> AccountRepository { get; }
    IGenericRepository<AccountType> AccountTypeRepository { get; }
    IGenericRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository { get; }
    IGenericRepository<Currency> CurrencyRepository { get; }
    IGenericRepository<Holder> HolderRepository { get; }
    IGenericRepository<Keeper> KeeperRepository { get; }
    IGenericRepository<Transaction> TransactionRepository { get; }
    IGenericRepository<TransactionItem> TransactionItemRepository { get; }
    int Complete();
}
