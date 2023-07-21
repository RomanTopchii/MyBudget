using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class AccountSimpleDto : DictionaryEntityDto
{
    public AccountSimpleDto(Domain.Account domain) : base(domain)
    {
    }
}