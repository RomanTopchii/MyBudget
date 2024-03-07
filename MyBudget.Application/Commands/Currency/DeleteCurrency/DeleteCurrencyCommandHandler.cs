using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;

namespace MyBudget.Application.Commands.Currency.DeleteCurrency;

public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = await this._unitOfWork.CurrencyRepository.GetByIdAsync(request.Id) 
                       ?? throw new ObjectNotFoundException<Domain.Currency>(request.Id);

        if (currency.IsAccounting)
        {
            throw new AccountingCurrencyCannotBeDeletedException(currency);
        }
        
        if (currency.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Keeper>(request.Id);
        }

        await _unitOfWork.CurrencyRepository.RemoveAsync(currency);
        _unitOfWork.Complete();
    }
}
