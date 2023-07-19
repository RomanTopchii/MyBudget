using MyBudget.Application.Domain;

namespace MyBudget.Application.Interfaces.Persistence.Repositories;

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
