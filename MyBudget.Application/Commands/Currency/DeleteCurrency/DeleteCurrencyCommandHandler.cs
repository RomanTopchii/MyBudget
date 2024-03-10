using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Commands.Currency.DeleteCurrency;

public record DeleteCurrencyCommandHandler(
    ICurrencyRepository CurrencyRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<DeleteCurrencyCommand>
{
    public async Task Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await this.CurrencyRepository.GetByIdAsync(request.Id)
                       ?? throw new ObjectNotFoundException<Domain.Currency>(request.Id);

        if (currency.IsAccounting)
        {
            throw new AccountingCurrencyCannotBeDeletedException(currency);
        }

        if (currency.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Currency>(request.Id);
        }

        this.CurrencyRepository.Remove(currency);
        this.UnitOfWork.Complete();
    }
}
