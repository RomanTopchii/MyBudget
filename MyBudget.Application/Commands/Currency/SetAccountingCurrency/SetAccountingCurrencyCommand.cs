using MediatR;

namespace MyBudget.Application.Commands.Currency.SetAccountingCurrency;

public class SetAccountingCurrencyCommand : IRequest
{
    public Guid NewAccountingCurrencyId { get; set; }
}
