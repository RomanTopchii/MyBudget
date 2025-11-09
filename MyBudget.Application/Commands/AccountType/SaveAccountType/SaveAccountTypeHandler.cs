using MediatR;
using MyBudget.Domain;
using MyBudget.Domain.Core;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.AccountType.SaveAccountType;

public record SaveAccountTypeHandler(
    IRepository<Domain.AccountType> AccountTypeRepository,
    IRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository,
    IUnitOfWork UnitOfWork)
    : IRequestHandler<SaveAccountType>
{
    public async Task Handle(SaveAccountType request, CancellationToken cancellationToken)
    {
        if (await this.AccountTypeRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.AccountType>(new DictionaryEntity
                { Name = request.Name });
        }

        var accountType = request.Id != null
            ? await this.AccountTypeRepository.GetByIdAsync((Guid)request.Id)
            : null;

        if (accountType == null)
        {
            accountType = new Domain.AccountType();
            await this.AccountTypeRepository.AddAsync(accountType);
        }

        accountType.Id = request.Id ?? Guid.NewGuid();
        accountType.Active = request.Active;
        accountType.Name = request.Name;
        accountType.Classification = request.Classification;
        accountType.HasCurrency = request.HasCurrency;
        accountType.HasHolder = request.HasHolder;
        accountType.HasKeeper = request.HasKeeper;
        accountType.LinkedAccountType = request.LinkedAccountTypeId is not null
            ? await AccountTypeRepository.GetByIdAsync((Guid)request.LinkedAccountTypeId) ??
              throw new ObjectNotFoundException<Domain.AccountType>((Guid)request.LinkedAccountTypeId)
            : null;
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

        this.UnitOfWork.Complete();
    }
}