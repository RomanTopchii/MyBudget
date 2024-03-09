using MediatR;

namespace MyBudget.Application.Commands.Currency.DeleteCurrency;

public record DeleteCurrencyCommand(Guid Id) : IRequest;
