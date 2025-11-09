using MediatR;
using MyBudget.Domain;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.AccountType.DeleteAccountTypeLink;

public record DeleteAccountTypeLinkHandler(
    IRepository<Domain.AccountType> AccountTypeRepository,
    IRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository,
    IUnitOfWork UnitOfWork)
    : IRequestHandler<DeleteAccountTypeLink>
{
    public async Task Handle(DeleteAccountTypeLink request, CancellationToken cancellationToken)
    {
        var link = (await this.AccountTypeAccountTypeLinkRepository
                       .FindAsync(x => x.ChildId == request.ChildId && x.AncestorId == request.AncestorId))
                   .SingleOrDefault() ??
                   throw new ObjectNotFoundException<Domain.AccountTypeAccountTypeLink>("Link not found");

        this.AccountTypeAccountTypeLinkRepository.Remove(link);

        this.UnitOfWork.Complete();
    }
}