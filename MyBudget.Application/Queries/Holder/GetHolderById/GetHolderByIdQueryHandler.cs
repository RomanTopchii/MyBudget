using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Queries.Holder.GetHolderById;

public record GetHolderByIdQueryHandler(IHolderRepository HolderRepository)
    : IRequestHandler<GetHolderByIdQuery, HolderSimpleDto>
{
    public async Task<HolderSimpleDto> Handle(GetHolderByIdQuery request, CancellationToken cancellationToken)
    {
        var currency = await this.HolderRepository.GetByIdAsync(request.Id)
                       ?? throw new ObjectNotFoundException<Domain.Holder>(request.Id);

        return new HolderSimpleDto(currency);
    }
}