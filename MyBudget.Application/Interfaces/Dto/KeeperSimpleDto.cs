using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class KeeperSimpleDto : DictionaryEntityDto
{
    public KeeperSimpleDto(Domain.Keeper domain) : base(domain)
    {
    }
}
