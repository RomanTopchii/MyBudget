using MediatR;

namespace MyBudget.Application.Features.Currency.Commands.SetAccountingCurrency;

public class SetAccountingCurrencyCommand : IRequest
{
    public Guid NewAccountingCurrencyId { get; set; }
}
