using MediatR;

namespace MyBudget.Application.Commands.Currency.DeleteCurrency;

public record DeleteCurrency(Guid Id) : IRequest;
