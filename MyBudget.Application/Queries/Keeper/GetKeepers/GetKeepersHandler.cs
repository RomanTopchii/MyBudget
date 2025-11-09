using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Keeper.GetKeepers;

public record GetKeepersHandler(IKeeperRepository KeeperRepository)
    : IRequestHandler<GetKeepers, List<KeeperSimpleDto>>
{
    public async Task<List<KeeperSimpleDto>> Handle(GetKeepers request, CancellationToken cancellationToken)
    {
        return (await this.KeeperRepository.GetAllAsync())
            .Select(x => new KeeperSimpleDto(x))
            .OrderBy(x => x.Name)
            .ToList();
    }
}
