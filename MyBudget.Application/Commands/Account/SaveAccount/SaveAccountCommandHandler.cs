using MediatR;
using MyBudget.Domain.Core;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.Account.SaveAccount;

public record SaveAccountCommandHandler(
        IAccountRepository AccountRepository,
        IRepository<Domain.AccountType> AccountTypeRepository,
        ICurrencyRepository CurrencyRepository,
        IHolderRepository HolderRepository,
        IKeeperRepository KeeperRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<SaveAccountCommand>
{
    public async Task Handle(SaveAccountCommand request, CancellationToken cancellationToken)
    {
        if (await this.AccountRepository.AnyAsync(x =>
                x.Name == request.Name && x.Id != request.Id && x.ParentId == request.ParentId))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Account>(new DictionaryEntity
                { Name = request.Name });
        }

        var accountType = await this.AccountTypeRepository.GetByIdAsync(request.TypeId) ??
                          throw new ObjectNotFoundException<Domain.AccountType>(request.TypeId);

        Domain.Account? account = null;
        if (request.Id != null)
        {
            account = await this.AccountRepository.GetByIdAsync((Guid)request.Id);
        }

        if (account == null)
        {
            account = new Domain.Account();
            await this.AccountRepository.AddAsync(account);
        }

        account.Id = request.Id ?? Guid.NewGuid();
        account.Active = request.Active;
        account.Name = request.Name;
        account.Type = accountType;

        Domain.Account? parent = null;
        if (request.ParentId != null)
        {
            parent = await this.AccountRepository.GetByIdAsync((Guid)request.ParentId) ??
                     throw new ObjectNotFoundException<Domain.Account>((Guid)request.ParentId);
            account.Parent = parent;

            var possibleAccountTypes = await this.AccountTypeRepository
                .FindAsync(x => x.AncestorAccountTypeLinks.Any(l => l.AncestorId == parent.TypeId));
            if (!possibleAccountTypes.Select(x => x.Id).Contains(request.TypeId))
            {
                throw new AccountTypeDoesNotCorrelateParentTypeException();
            }
        }

        account.Currency = CalcValue(
            accountType.HasCurrency,
            request.CurrencyId,
            (await this.CurrencyRepository.FindAsync(x => x.Id == request.CurrencyId)).SingleOrDefault()
        );

        account.Keeper = CalcValue(
            accountType.HasKeeper,
            request.KeeperId,
            (await this.KeeperRepository.FindAsync(x => x.Id == request.KeeperId)).SingleOrDefault()
        );

        account.Holder = CalcValue(
            accountType.HasHolder,
            request.HolderId,
            (await this.HolderRepository.FindAsync(x => x.Id == request.HolderId)).SingleOrDefault()
        );

        account.LinkedAccount = CalcValue(
            accountType.HasLinkedAccount,
            request.LinkedAccountId,
            (await this.AccountRepository.FindAsync(x => x.Id == request.LinkedAccountId)).SingleOrDefault()
        );

        this.UnitOfWork.Complete();
    }

    private T? CalcValue<T>(
        bool hasValue,
        Guid? requestPropertyId,
        T? propertyValue)
    {
        if (!hasValue && requestPropertyId != null)
        {
            throw new DynamicAccountException($"Account should not has {typeof(T).Name.ToLower()}");
        }
        else if (hasValue)
        {
            if (requestPropertyId != null)
            {
                if (propertyValue == null)
                {
                    throw new ObjectNotFoundException<T>((Guid)requestPropertyId);
                }
                else
                {
                    return propertyValue;
                }
            }
            else
            {
                throw new DynamicAccountException($"Account should has {typeof(T).Name.ToLower()}");
            }
        }
        else
        {
            return default;
        }
    }
}
