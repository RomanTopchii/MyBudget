using MediatR;

namespace MyBudget.Application.Commands.Currency.DeleteCurrency;

public class DeleteCurrencyCommand : IRequest
{
    public Guid Id { get; set; }
}
