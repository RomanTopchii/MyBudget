using MyBudget.Application.Domain;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Infrastructure.Persistence.Repositories;

namespace MyBudget.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IGenericRepository<Account> AccountRepository { get; }

    public IGenericRepository<AccountType> AccountTypeRepository { get; }

    public IGenericRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository { get; }

    public IGenericRepository<Currency> CurrencyRepository { get; }

    public IGenericRepository<Holder> HolderRepository { get; }

    public IGenericRepository<Keeper> KeeperRepository { get; }

    public IGenericRepository<Transaction> TransactionRepository { get; }

    public IGenericRepository<TransactionItem> TransactionItemRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        this._context = context;
        this.AccountRepository = new GenericRepository<Account>(this._context);
        this.AccountTypeRepository = new GenericRepository<AccountType>(this._context);
        this.AccountTypeAccountTypeLinkRepository = new GenericRepository<AccountTypeAccountTypeLink>(this._context);
        this.CurrencyRepository = new CurrencyRepository(this._context);
        this.HolderRepository = new HolderRepository(this._context);
        this.KeeperRepository = new KeeperRepository(this._context);
        this.TransactionRepository = new GenericRepository<Transaction>(this._context);
        this.TransactionItemRepository = new GenericRepository<TransactionItem>(this._context);
    }

    public int Complete()
    {
        return this._context.SaveChanges();
    }
}
