using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Queries.Keeper.GetKeeperById;

public record GetKeeperByIdHandler(IKeeperRepository KeeperRepository)
    : IRequestHandler<GetKeeperById, KeeperSimpleDto>
{
    public async Task<KeeperSimpleDto> Handle(GetKeeperById request, CancellationToken cancellationToken)
    {
        var currency = await this.KeeperRepository.GetByIdAsync(request.Id)
                       ?? throw new ObjectNotFoundException<Domain.Keeper>(request.Id);

        return new KeeperSimpleDto(currency);
    }
}