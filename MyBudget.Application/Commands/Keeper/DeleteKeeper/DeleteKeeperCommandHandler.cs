using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.Keeper.DeleteKeeper;

public record DeleteKeeperCommandHandler(
    IKeeperRepository KeeperRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<DeleteKeeperCommand>
{
    public async Task Handle(DeleteKeeperCommand request, CancellationToken cancellationToken)
    {
        var keeper = await this.KeeperRepository.GetByIdAsync(request.Id);
        if (keeper == null)
        {
            throw new ObjectNotFoundException<Domain.Keeper>(request.Id);
        }

        if (keeper.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Keeper>(request.Id);
        }

        this.KeeperRepository.Remove(keeper);
        this.UnitOfWork.Complete();
    }
}
