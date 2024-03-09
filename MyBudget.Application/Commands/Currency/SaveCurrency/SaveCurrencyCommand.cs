using MediatR;

namespace MyBudget.Application.Commands.Currency.SaveCurrency;

public record SaveCurrencyCommand(Guid? Id,
    bool Active,
    string Name,
    string Code,
    int Iso4217
) : IRequest;
