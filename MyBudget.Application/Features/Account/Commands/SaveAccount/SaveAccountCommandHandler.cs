using MediatR;
using MyBudget.Domain.Core;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Account.Commands.SaveAccount;

public class SaveAccountCommandHandler : IRequestHandler<SaveAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveAccountCommand request, CancellationToken cancellationToken)
    {
        if (await this._unitOfWork.AccountRepository.AnyAsync(x =>
                x.Name == request.Name && x.Id != request.Id && x.ParentId == request.ParentId))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Account>(new DictionaryEntity
                { Name = request.Name });
        }

        var accountType = await this._unitOfWork.AccountTypeRepository.GetByIdAsync(request.TypeId) ??
                          throw new ObjectNotFoundException<Domain.AccountType>(request.TypeId);

        Domain.Account? account = null;
        if (request.Id != null)
        {
            account = await this._unitOfWork.AccountRepository.GetByIdAsync((Guid)request.Id);
        }

        if (account == null)
        {
            account = new Domain.Account();
            await this._unitOfWork.AccountRepository.AddAsync(account);
        }

        account.Id = request.Id ?? Guid.NewGuid();
        account.Active = request.Active;
        account.Name = request.Name;
        account.Type = accountType;

        Domain.Account? parent = null;
        if (request.ParentId != null)
        {
            parent = await this._unitOfWork.AccountRepository.GetByIdAsync((Guid)request.ParentId) ??
                     throw new ObjectNotFoundException<Domain.Account>((Guid)request.ParentId);
            account.Parent = parent;

            var possibleAccountTypes = await this._unitOfWork.AccountTypeRepository
                .FindAsync(x => x.AncestorAccountTypeLinks.Any(l => l.AncestorId == parent.TypeId));
            if (!possibleAccountTypes.Select(x => x.Id).Contains(request.TypeId))
            {
                throw new AccountTypeDoesNotCorrelateParentTypeException();
            }
        }

        account.Currency = CalcValue(
            accountType.HasCurrency,
            request.CurrencyId,
            (await this._unitOfWork.CurrencyRepository.FindAsync(x => x.Id == request.CurrencyId)).SingleOrDefault()
        );

        account.Keeper = CalcValue(
            accountType.HasKeeper,
            request.KeeperId,
            (await this._unitOfWork.KeeperRepository.FindAsync(x => x.Id == request.KeeperId)).SingleOrDefault()
        );

        account.Holder = CalcValue(
            accountType.HasHolder,
            request.HolderId,
            (await this._unitOfWork.HolderRepository.FindAsync(x => x.Id == request.HolderId)).SingleOrDefault()
        );

        account.LinkedAccount = CalcValue(
            accountType.HasLinkedAccount,
            request.LinkedAccountId,
            (await this._unitOfWork.AccountRepository.FindAsync(x => x.Id == request.LinkedAccountId)).SingleOrDefault()
        );

        this._unitOfWork.Complete();
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
