using MyBudget.Application.Interfaces.Dto.Core;
using MyBudget.Domain;

namespace MyBudget.Application.Interfaces.Dto;

public class AccountTypeNamedDto :  DictionaryEntityDto
{
    public AccountTypeNamedDto(AccountType domain) : base(domain)
    {
    }
}