using MediatR;
using MyBudget.Application.Features.Keeper.Queries.GetKeepers;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Holder.Queries.GetHolders;

public class GetHoldersQueryHandler : IRequestHandler<GetHoldersQuery, List<HolderSimpleDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHoldersQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<List<HolderSimpleDto>> Handle(GetHoldersQuery request, CancellationToken cancellationToken)
    {
        return (await this._unitOfWork.HolderRepository.GetAllAsync())
            .Select(x => new HolderSimpleDto(x))
            .ToList();
    }
}
