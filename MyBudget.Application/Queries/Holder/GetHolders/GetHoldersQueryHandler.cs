using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Holder.GetHolders;

public record GetHoldersQueryHandler(IHolderRepository HolderRepository)
    : IRequestHandler<GetHoldersQuery, List<HolderSimpleDto>>
{
    public async Task<List<HolderSimpleDto>> Handle(GetHoldersQuery request, CancellationToken cancellationToken)
    {
        return (await this.HolderRepository.GetAllAsync())
            .Select(x => new HolderSimpleDto(x))
            .ToList();
    }
}
