using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Core;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.Keeper.SaveKeeper;

public record SaveKeeperCommandHandler(
    IKeeperRepository KeeperRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<SaveKeeperCommand>
{
    public async Task Handle(SaveKeeperCommand request, CancellationToken cancellationToken)
    {
        if (await this.KeeperRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Keeper>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.Keeper? keeper = null;
        if (request.Id != null)
        {
            keeper = await this.KeeperRepository.GetByIdAsync((Guid)request.Id);
        }

        if (keeper == null)
        {
            keeper = new Domain.Keeper();
            await this.KeeperRepository.AddAsync(keeper);
        }

        keeper.Id = request.Id ?? Guid.NewGuid();
        keeper.Active = request.Active;
        keeper.Name = request.Name;
        keeper.Type = request.Type;
        
        this.UnitOfWork.Complete();
    }
}
