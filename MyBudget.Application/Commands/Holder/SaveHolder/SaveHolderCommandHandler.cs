using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Core;

namespace MyBudget.Application.Commands.Holder.SaveHolder;

public record SaveHolderCommandHandler(
    IHolderRepository HolderRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<SaveHolderCommand>
{
    public async Task Handle(SaveHolderCommand request, CancellationToken cancellationToken)
    {
        if (await this.HolderRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Holder>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.Holder? holder = null;
        if (request.Id != null)
        {
            holder = await this.HolderRepository.GetByIdAsync((Guid)request.Id);
        }

        if (holder == null)
        {
            holder = new Domain.Holder();
            await this.HolderRepository.AddAsync(holder);
        }

        holder.Id = request.Id ?? Guid.NewGuid();
        holder.Active = request.Active;
        holder.Name = request.Name;
        this.UnitOfWork.Complete();
    }
}
