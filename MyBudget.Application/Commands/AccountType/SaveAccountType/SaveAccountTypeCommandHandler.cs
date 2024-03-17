using MediatR;
using MyBudget.Domain;
using MyBudget.Domain.Core;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Commands.AccountType.SaveAccountType;

public record SaveAccountTypeCommandHandler(
        IRepository<Domain.AccountType> AccountTypeRepository,
        IRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<SaveAccountTypeCommand>
{
    public async Task Handle(SaveAccountTypeCommand request, CancellationToken cancellationToken)
    {
        if (await this.AccountTypeRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.AccountType>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.AccountType? accountType = null;
        if (request.Id != null)
        {
            accountType = await this.AccountTypeRepository.GetByIdAsync((Guid)request.Id);
        }

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

        var accountTypeAccountTypeLinks = await this.AccountTypeAccountTypeLinkRepository
            .FindAsync(x => x.ChildId == request.Id);

        foreach (var parentIdToAdd in request.ParentTypes
                     .Where(x => !accountTypeAccountTypeLinks.Select(y => y.AncestorId).Contains(x)))
        {
            var ancestor = await this.AccountTypeRepository.GetByIdAsync(parentIdToAdd) ??
                           throw new ObjectNotFoundException<Domain.AccountType>(parentIdToAdd);
            
            var accountTypeAccountTypeLink = new AccountTypeAccountTypeLink
            {
                Active = true,
                Ancestor = ancestor,
                Child = accountType
            };
            await this.AccountTypeAccountTypeLinkRepository.AddAsync(accountTypeAccountTypeLink);
        }

        foreach (var accountTypeAccountTypeLink in accountTypeAccountTypeLinks.Where(x => !request.ParentTypes
                     .Contains(x.AncestorId)))
        {
            this.AccountTypeAccountTypeLinkRepository.Remove(accountTypeAccountTypeLink);
        }

        this.UnitOfWork.Complete();
    }
}
