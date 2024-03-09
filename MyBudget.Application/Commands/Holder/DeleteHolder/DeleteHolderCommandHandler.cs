using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public record DeleteHolderCommandHandler(
        IHolderRepository HolderRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<DeleteHolderCommand>
{
    public async Task Handle(DeleteHolderCommand request, CancellationToken cancellationToken)
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
