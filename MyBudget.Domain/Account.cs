using MyBudget.Domain.Core;

namespace MyBudget.Domain;

public class Account : DictionaryEntity
{
    public Guid? ParentId { get; set; }

    public virtual Account? Parent { get; set; }

    public Guid TypeId { get; set; }

    public virtual AccountType Type { get; set; } = new();

    public Guid? CurrencyId { get; set; }

    public virtual Currency? Currency { get; set; }

    public Guid? HolderId { get; set; }

    public virtual Holder? Holder { get; set; }

    public Guid? KeeperId { get; set; }

    public virtual Keeper? Keeper { get; set; }

    public Guid? LinkedAccountId { get; set; }

    public virtual Account? LinkedAccount { get; set; }

    public virtual ICollection<Account> Children { get; set; } = new List<Account>();

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
