using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Commands.Currency.SetAccountingCurrency;

public record SetAccountingCurrencyCommandHandler(
        ICurrencyRepository CurrencyRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<SetAccountingCurrencyCommand>
{
    public async Task Handle(SetAccountingCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currentAccountingCurrency = (await this.CurrencyRepository.FindAsync(x => x.IsAccounting))
            .SingleOrDefault();

        var newAccountingCurrency =
            await this.CurrencyRepository.GetByIdAsync(request.NewAccountingCurrencyId) ??
            throw new ObjectNotFoundException<Domain.Currency>(request.NewAccountingCurrencyId);

        if (currentAccountingCurrency == null)
        {
            newAccountingCurrency.IsAccounting = true;
        }
        else
        {
            if (await this.CurrencyRepository.AnyAsync(x =>
                    x.Id == currentAccountingCurrency.Id && x.Accounts.Any(y => y.TransactionItems.Any())))
            {
                throw new CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException();
            }

            currentAccountingCurrency.IsAccounting = false;
            newAccountingCurrency.IsAccounting = true;
        }

        this.UnitOfWork.Complete();
    }
}
