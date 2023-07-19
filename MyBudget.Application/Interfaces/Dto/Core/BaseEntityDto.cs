using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Interfaces.Dto.Core;

public class BaseEntityDto : IdentifiableDto
{
    public bool Active { get; set; }

    public BaseEntityDto(BaseEntity domain) : base(domain)
    {
        this.Active = domain.Active;
    }
}
