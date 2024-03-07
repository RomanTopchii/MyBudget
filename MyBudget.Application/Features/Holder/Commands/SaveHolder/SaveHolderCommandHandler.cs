using MediatR;
using MyBudget.Domain.Core;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Holder.Commands.SaveHolder;

public class SaveHolderCommandHandler : IRequestHandler<SaveHolderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveHolderCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveHolderCommand request, CancellationToken cancellationToken)
    {
        if (await this._unitOfWork.HolderRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Holder>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.Holder? holder = null;
        if (request.Id != null)
        {
            holder = await this._unitOfWork.HolderRepository.GetByIdAsync((Guid)request.Id);
        }

        if (holder == null)
        {
            holder = new Domain.Holder();
            await this._unitOfWork.HolderRepository.AddAsync(holder);
        }

        holder.Id = request.Id ?? Guid.NewGuid();
        holder.Active = request.Active;
        holder.Name = request.Name;
        this._unitOfWork.Complete();
    }
}
