using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Keeper.GetKeeperById;

public record GetKeeperByIdQuery(Guid Id) : IRequest<KeeperSimpleDto>;