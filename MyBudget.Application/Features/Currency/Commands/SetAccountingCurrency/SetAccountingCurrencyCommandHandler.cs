using MediatR;
using MyBudget.Application.Domain.Core;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Features.Currency.Commands.SaveCurrency;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Currency.Commands.SetAccountingCurrency;

public class SetAccountingCurrencyCommandHandler : IRequestHandler<SetAccountingCurrencyCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SetAccountingCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SetAccountingCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currentAccountingCurrency = (await this._unitOfWork.CurrencyRepository.FindAsync(x => x.IsAccounting))
            .SingleOrDefault();

        var newAccountingCurrency =
            await this._unitOfWork.CurrencyRepository.GetByIdAsync(request.NewAccountingCurrencyId) ??
            throw new ObjectNotFoundException<Domain.Currency>(request.NewAccountingCurrencyId);

        if (currentAccountingCurrency == null)
        {
            newAccountingCurrency.IsAccounting = true;
        }
        else
        {
            if (await this._unitOfWork.CurrencyRepository.AnyAsync(x =>
                    x.Id == currentAccountingCurrency.Id && x.Accounts.Any(y => y.TransactionItems.Any())))
            {
                throw new CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException();
            }

            currentAccountingCurrency.IsAccounting = false;
            newAccountingCurrency.IsAccounting = true;
        }

        this._unitOfWork.Complete();
    }
}
