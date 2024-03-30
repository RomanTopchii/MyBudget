using MyBudget.Domain.Attributes;
using MyBudget.Domain.Core;
using MyBudget.Domain.Enums;

namespace MyBudget.Domain;

[Auditable]
public class Transaction : BaseEntity
{
    public DateTime Date { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionType Type { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
