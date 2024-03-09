using MyBudget.Domain.Core;
using MyBudget.Domain.Enums;

namespace MyBudget.Domain;

public class TransactionItem : BaseEntity
{
    public Double Amount { get; set; }

    public TransactionItemType Type { get; set; }

    public Guid AccountId { get; set; }

    public Account Account { get; set; } = new();

    public Guid TransactionId { get; set; }

    public virtual Transaction Transaction { get; set; } = new();
}
