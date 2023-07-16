using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Domain;

public class Account : DictionaryEntity
{
    public Guid? ParentId { get; set; }

    public Account? Parent { get; set; }

    public Guid TypeId { get; set; }

    public AccountType Type { get; set; } = new();

    public Guid? CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid? HolderId { get; set; }

    public Holder? Holder { get; set; }

    public Guid? KeeperId { get; set; }

    public Keeper? Keeper { get; set; }

    public Guid? LinkedAccountId { get; set; }

    public Account? LinkedAccount { get; set; }

    public List<Account> Children { get; set; } = new List<Account>();

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
