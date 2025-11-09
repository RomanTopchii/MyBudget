using MediatR;
using MyBudget.Domain;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.AccountType.AddLinkedAccountType;

public record AddLinkedAccountTypeHandler(
    IRepository<Domain.AccountType> AccountTypeRepository,
    IRepository<AccountTypeAccountTypeLink> AccountTypeAccountTypeLinkRepository,
    IUnitOfWork UnitOfWork)
    : IRequestHandler<AddLinkedAccountType>
{
    public async Task Handle(AddLinkedAccountType request, CancellationToken cancellationToken)
    {
        var accountType = await this.AccountTypeRepository.GetByIdAsync(request.AccountTypeId) ??
                          throw new ObjectNotFoundException<Domain.AccountType>(request.AccountTypeId);

        var linkedAccountType = await this.AccountTypeRepository.GetByIdAsync(request.LinkedAccountTypeId) ??
                                  throw new ObjectNotFoundException<Domain.AccountType>(request.LinkedAccountTypeId);
        
        accountType.LinkedAccountType = linkedAccountType;
        linkedAccountType.LinkedAccountType = accountType;
        
        this.UnitOfWork.Complete();
    }
}