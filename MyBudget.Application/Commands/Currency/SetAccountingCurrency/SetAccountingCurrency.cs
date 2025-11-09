using MediatR;

namespace MyBudget.Application.Commands.Currency.SetAccountingCurrency;

public record SetAccountingCurrency(Guid NewAccountingCurrencyId) : IRequest;
