using MyBudget.Domain.Enums;
using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class TransactionItemDto : IdentifiableDto
{

    public AccountPoorDto Account { get; set; }

    public Double Amount { get; set; }

    public TransactionItemType Type { get; set; }

    public TransactionItemDto(Domain.TransactionItem domain) : base(domain)
    {
        this.Account = new AccountPoorDto(domain.Account);
        this.Amount = domain.Amount;
        this.Type = domain.Type;
    }
}