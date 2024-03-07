using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence;

namespace MyBudget.Application.Queries.Keeper.GetKeepers;

public class GetKeepersQueryHandler : IRequestHandler<GetKeepersQuery, List<KeeperSimpleDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetKeepersQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<List<KeeperSimpleDto>> Handle(GetKeepersQuery request, CancellationToken cancellationToken)
    {
        return (await this._unitOfWork.KeeperRepository.GetAllAsync())
            .Select(x => new KeeperSimpleDto(x))
            .ToList();
    }
}
