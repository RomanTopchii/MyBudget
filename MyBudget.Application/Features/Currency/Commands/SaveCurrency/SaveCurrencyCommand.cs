using MediatR;

namespace MyBudget.Application.Features.Currency.Commands.SaveCurrency;

public class SaveCurrencyCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;
    
    public int Iso4217 { get; set; }
}
