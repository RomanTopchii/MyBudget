using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Holder.GetHolders;

public record GetHoldersHandler(IHolderRepository HolderRepository)
    : IRequestHandler<GetHolders, List<HolderSimpleDto>>
{
    public async Task<List<HolderSimpleDto>> Handle(GetHolders request, CancellationToken cancellationToken)
    {
        return (await this.HolderRepository.GetAllAsync())
            .Select(x => new HolderSimpleDto(x))
            .OrderBy(x => x.Name)
            .ToList();
    }
}
