using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Domain.Core;

namespace MyBudget.Application.Commands.Currency.SaveCurrency;

public class SaveCurrencyCommandHandler : IRequestHandler<SaveCurrencyCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveCurrencyCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveCurrencyCommand request, CancellationToken cancellationToken)
    {
        if (await this._unitOfWork.CurrencyRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Currency>(new DictionaryEntity
                { Name = request.Name });
        }
        
        if (await this._unitOfWork.CurrencyRepository.AnyAsync(x => x.Code == request.Code && x.Id != request.Id))
        {
            throw new CurrencyWithSameCodeAlreadyExistsException(new Domain.Currency{Code = request.Code});
        }
        
        if (await this._unitOfWork.CurrencyRepository.AnyAsync(x => x.Iso4217 == request.Iso4217 && x.Id != request.Id))
        {
            throw new CurrencyWithSameIso4217AlreadyExistsException(request.Iso4217.ToString());
        }

        Domain.Currency? currency = null;
        if (request.Id != null)
        {
            currency = await this._unitOfWork.CurrencyRepository.GetByIdAsync((Guid)request.Id);
        }

        if (currency == null)
        {
            currency = new Domain.Currency();
            await this._unitOfWork.CurrencyRepository.AddAsync(currency);
        }

        if (!request.Active && currency.IsAccounting)
        {
            throw new AccountingCurrencyCannotBeDeactivatedException();
        }
        
        currency.Id = request.Id ?? Guid.NewGuid();
        currency.Active = request.Active;
        currency.Name = request.Name;
        currency.Code = request.Code;
        currency.Iso4217 = request.Iso4217;
        currency.IsAccounting = false;
        this._unitOfWork.Complete();
    }
}
