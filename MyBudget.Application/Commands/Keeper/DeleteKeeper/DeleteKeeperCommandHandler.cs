using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;

namespace MyBudget.Application.Commands.Keeper.DeleteKeeper;

public class DeleteKeeperCommandHandler : IRequestHandler<DeleteKeeperCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteKeeperCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteKeeperCommand request, CancellationToken cancellationToken)
    {
        var keeper = await this._unitOfWork.KeeperRepository.GetByIdAsync(request.Id);
        if (keeper == null)
        {
            throw new ObjectNotFoundException<Domain.Keeper>(request.Id);
        }

        if (keeper.Accounts.Any())
        {
            throw new ObjectUsedInAccountException<Domain.Keeper>(request.Id);
        }

        await _unitOfWork.KeeperRepository.RemoveAsync(keeper);
        _unitOfWork.Complete();
    }
}
