using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Core;

namespace MyBudget.Application.Commands.Currency.SaveCurrency;

public record SaveCurrencyCommandHandler(
        ICurrencyRepository CurrencyRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<SaveCurrencyCommand>
{
    public async Task Handle(SaveCurrencyCommand request, CancellationToken cancellationToken)
    {
        if (await this.CurrencyRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Currency>(new DictionaryEntity
                { Name = request.Name });
        }

        if (await this.CurrencyRepository.AnyAsync(x => x.Code == request.Code && x.Id != request.Id))
        {
            throw new CurrencyWithSameCodeAlreadyExistsException(new Domain.Currency { Code = request.Code });
        }

        if (await this.CurrencyRepository.AnyAsync(x => x.Iso4217 == request.Iso4217 && x.Id != request.Id))
        {
            throw new CurrencyWithSameIso4217AlreadyExistsException(request.Iso4217.ToString());
        }

        Domain.Currency? currency = null;
        if (request.Id != null)
        {
            currency = await this.CurrencyRepository.GetByIdAsync((Guid)request.Id);
        }

        if (currency == null)
        {
            currency = new Domain.Currency();
            await this.CurrencyRepository.AddAsync(currency);
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

        this.UnitOfWork.Complete();
    }
}
