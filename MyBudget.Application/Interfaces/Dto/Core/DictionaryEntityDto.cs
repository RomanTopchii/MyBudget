using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Interfaces.Dto.Core;

public class DictionaryEntityDto : BaseEntityDto
{
    public string Name { get; set; }

    public DictionaryEntityDto(DictionaryEntity domain) : base(domain)
    {
        Name = domain.Name;
    }
}
