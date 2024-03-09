using MediatR;

namespace MyBudget.Application.Commands.Currency.SetAccountingCurrency;

public record SetAccountingCurrencyCommand(Guid NewAccountingCurrencyId) : IRequest;
