using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Keeper.GetKeepers;

public record GetKeepersQueryHandler(IKeeperRepository KeeperRepository)
    : IRequestHandler<GetKeepersQuery, List<KeeperSimpleDto>>
{
    public async Task<List<KeeperSimpleDto>> Handle(GetKeepersQuery request, CancellationToken cancellationToken)
    {
        return (await this.KeeperRepository.GetAllAsync())
            .Select(x => new KeeperSimpleDto(x))
            .ToList();
    }
}
