using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Features.Keeper.Queries.GetKeepers;

public class GetKeepersQuery : IRequest<List<KeeperSimpleDto>>
{
}
