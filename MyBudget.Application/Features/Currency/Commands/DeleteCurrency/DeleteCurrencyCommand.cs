using MediatR;

namespace MyBudget.Application.Features.Currency.Commands.DeleteCurrency;

public class DeleteCurrencyCommand : IRequest
{
    public Guid Id { get; set; }
}
