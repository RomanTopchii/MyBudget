using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public class DeleteHolderCommandHandler : IRequestHandler<DeleteHolderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHolderCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteHolderCommand request, CancellationToken cancellationToken)
    {
        var holder = await this._unitOfWork.HolderRepository.GetByIdAsync(request.Id);
        if (holder == null)
        {
            throw new ObjectNotFoundException<Domain.Holder>(request.Id);
        }

        if (holder.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Holder>(request.Id);
        }

        await _unitOfWork.HolderRepository.RemoveAsync(holder);
        _unitOfWork.Complete();
    }
}
