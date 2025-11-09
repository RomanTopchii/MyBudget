using MediatR;
using MyBudget.Domain;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.AccountType.AddAccountTypeLink;

public record AddAccountTypeLinkHandler(
    IRepository<Domain.AccountType> AccountTypeRepository,
    IRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository,
    IUnitOfWork UnitOfWork)
    : IRequestHandler<AddAccountTypeLink>
{
    public async Task Handle(AddAccountTypeLink request, CancellationToken cancellationToken)
    {
        var accountType = await this.AccountTypeRepository.GetByIdAsync(request.ChildId) ??
                          throw new ObjectNotFoundException<Domain.AccountType>(request.ChildId);

        var ancestor = await this.AccountTypeRepository.GetByIdAsync(request.AncestorId) ??
                       throw new ObjectNotFoundException<Domain.AccountType>(request.AncestorId);

        if (await this.AccountTypeAccountTypeLinkRepository
                .AnyAsync(x => x.ChildId == request.ChildId))
        {
            throw new Exception($"Link between \"{accountType.Name}\" and \"{ancestor.Name}\" already exists.");
        }

        var accountTypeAccountTypeLink = new AccountTypeAccountTypeLink
        {
            Active = true,
            Ancestor = ancestor,
            Child = accountType
        };

        await this.AccountTypeAccountTypeLinkRepository.AddAsync(accountTypeAccountTypeLink);

        this.UnitOfWork.Complete();
    }
}