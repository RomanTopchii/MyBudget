using MyBudget.Domain.Enums;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Interfaces.Dto;

public class TransactionItemSimpleDto
{
    public Guid? Id { get; set; }

    public Double Amount { get; set; }

    public Guid AccountId { get; set; }

    public TransactionItemType Type { get; set; }

    public TransactionItemSimpleDto(Domain.TransactionItem domain)
    {
        this.Id = domain.Id;
        this.Amount = domain.Amount;
        this.AccountId = domain.AccountId;
        this.Type = domain.Type;
    }
}
