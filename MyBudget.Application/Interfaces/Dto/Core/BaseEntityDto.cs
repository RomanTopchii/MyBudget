using MyBudget.Domain.Core;

namespace MyBudget.Application.Interfaces.Dto.Core;

public class BaseEntityDto : IdentifiableDto
{
    public bool Active { get; set; }
    
    public DateTime? CreateDate { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public DateTime? ModifyDate { get; set; }
    
    public string? ModifiedBy { get; set; }

    public BaseEntityDto(BaseEntity domain) : base(domain)
    {
        this.Active = domain.Active;
        this.CreateDate = domain.CreateDate;
        this.CreatedBy = domain.CreatedBy;
        this.ModifyDate = domain.ModifyDate;
        this.ModifiedBy = domain.ModifiedBy;
    }
}
