using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class KeeperSimpleDto : DictionaryEntityDto
{
    public Domain.Enums.KeeperType Type { get; set; }

    public KeeperSimpleDto(Domain.Keeper domain) : base(domain)
    {
        this.Type = domain.Type;
    }
}
