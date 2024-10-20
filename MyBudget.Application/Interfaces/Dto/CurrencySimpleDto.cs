using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class CurrencySimpleDto : BaseEntityDto
{
    public string Code { get; set; }
    public int Iso4217 { get; set; }
    
    public CurrencySimpleDto(Domain.Currency domain) : base(domain)
    {
        this.Code = domain.Code;
        this.Iso4217 = domain.Iso4217;
    }
}
