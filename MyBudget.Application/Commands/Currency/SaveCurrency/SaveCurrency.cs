using MediatR;

namespace MyBudget.Application.Commands.Currency.SaveCurrency;

public record SaveCurrency(Guid? Id,
    bool Active,
    string Code,
    int Iso4217
) : IRequest;
