using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Domain.Core;

namespace MyBudget.Application.Commands.Keeper.SaveKeeper;

public class SaveKeeperCommandHandler : IRequestHandler<SaveKeeperCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveKeeperCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveKeeperCommand request, CancellationToken cancellationToken)
    {
        if (await this._unitOfWork.KeeperRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
        {
            throw new ObjectWithSameNameAlreadyExistsException<Domain.Keeper>(new DictionaryEntity
                { Name = request.Name });
        }

        Domain.Keeper? keeper = null;
        if (request.Id != null)
        {
            keeper = await this._unitOfWork.KeeperRepository.GetByIdAsync((Guid)request.Id);
        }

        if (keeper == null)
        {
            keeper = new Domain.Keeper();
            await this._unitOfWork.KeeperRepository.AddAsync(keeper);
        }

        keeper.Id = request.Id ?? Guid.NewGuid();
        keeper.Active = request.Active;
        keeper.Name = request.Name;
        keeper.Type = request.Type;
        this._unitOfWork.Complete();
    }
}
