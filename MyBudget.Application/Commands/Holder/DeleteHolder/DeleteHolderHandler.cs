using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public record DeleteHolderHandler(
        IHolderRepository HolderRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<DeleteHolder>
{
    public async Task Handle(DeleteHolder request, CancellationToken cancellationToken)
    {
        var holder = await this.HolderRepository.GetByIdAsync(request.Id);
        if (holder == null)
        {
            throw new ObjectNotFoundException<Domain.Holder>(request.Id);
        }

        if (holder.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Holder>(request.Id);
        }

        this.HolderRepository.Remove(holder);
        this.UnitOfWork.Complete();
    }
}
