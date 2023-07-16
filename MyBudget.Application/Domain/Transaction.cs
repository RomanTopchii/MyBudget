using MyBudget.Application.Domain.Core;
using MyBudget.Application.Domain.Enums;

namespace MyBudget.Application.Domain;

public class Transaction : BaseEntity
{
    public DateTime Date { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionType Type { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
