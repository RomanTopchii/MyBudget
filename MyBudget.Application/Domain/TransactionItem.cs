using MyBudget.Application.Domain.Core;
using MyBudget.Application.Domain.Enums;

namespace MyBudget.Application.Domain;

public class TransactionItem : BaseEntity
{
    public Double Amount { get; set; }

    public TransactionItemType Type { get; set; }

    public Guid AccountId { get; set; }

    public Account Account { get; set; } = new();

    public Guid TransactionId { get; set; }

    public Transaction Transaction { get; set; } = new();
}
