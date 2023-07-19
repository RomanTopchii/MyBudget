using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class HolderSimpleDto : DictionaryEntityDto
{
    public HolderSimpleDto(Domain.Holder domain) : base(domain)
    {
    }
}
