using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Interfaces.Dto.Core;

public class IdentifiableDto
{
    public Guid Id { get; set; }

    public IdentifiableDto(BaseEntity domain)
    {
        Id = domain.Id;
    }
}
