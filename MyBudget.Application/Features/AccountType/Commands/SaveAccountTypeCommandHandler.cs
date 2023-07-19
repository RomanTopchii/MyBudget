using MediatR;
using MyBudget.Application.Domain;
using MyBudget.Application.Domain.Core;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.AccountType.Commands;

public class SaveAccountTypeCommandHandler : IRequestHandler<SaveAccountTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveAccountTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveAccountTypeCommand request, CancellationToken cancellationToken)
    {
        if (await this._unitOfWork.CurrencyRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.AccountType>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.AccountType? accountType = null;
        if (request.Id != null)
        {
            accountType = await this._unitOfWork.AccountTypeRepository.GetByIdAsync((Guid)request.Id);
        }

        if (accountType == null)
        {
            accountType = new Domain.AccountType();
            await this._unitOfWork.AccountTypeRepository.AddAsync(accountType);
        }

        accountType.Id = request.Id ?? Guid.NewGuid();
        accountType.Active = request.Active;
        accountType.Name = request.Name;
        accountType.Classification = request.Classification;
        accountType.HasCurrency = request.HasCurrency;
        accountType.HasHolder = request.HasHolder;
        accountType.HasKeeper = request.HasKeeper;
        accountType.HasInitialBalance = request.HasInitialBalance;
        accountType.CalcFullTimeBalance = request.CalcFullTimeBalance;
        accountType.CanBeDeleted = request.CanBeDeleted;
        accountType.CanChangeActiveStatus = request.CanChangeActiveStatus;
        accountType.CanBeRenamed = request.CanBeRenamed;
        accountType.CanBeCreatedByUser = request.CanBeCreatedByUser;
        accountType.CheckAmountBeforeDeactivate = request.CheckAmountBeforeDeactivate;
        accountType.AllowsTransactions = request.AllowsTransactions;
        accountType.KeeperGroup = request.KeeperGroup;
        accountType.Priority = request.Priority;

        var accountTypeAccountTypeLinks = await _unitOfWork.AccountTypeAccountTypeLinkRepository
            .FindAsync(x => x.ChildId == request.Id);

        foreach (var parentIdToAdd in request.ParentTypes.Select(x => x.Id)
                     .Where(x => !accountTypeAccountTypeLinks.Select(y => y.AncestorId).Contains(x)))
        {
            var accountTypeAccountTypeLink = new AccountTypeAccountTypeLink
            {
                Active = true,
                AncestorId = parentIdToAdd,
                ChildId = accountType.Id
            };
            await this._unitOfWork.AccountTypeAccountTypeLinkRepository.AddAsync(accountTypeAccountTypeLink);
        }

        foreach (var accountTypeAccountTypeLink in accountTypeAccountTypeLinks.Where(x => !request.ParentTypes
                     .Select(x => x.Id).Contains(x.AncestorId)))
        {
            await this._unitOfWork.AccountTypeAccountTypeLinkRepository.RemoveAsync(accountTypeAccountTypeLink);
        }

        this._unitOfWork.Complete();
    }
}
