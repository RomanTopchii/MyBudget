using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Keeper.GetKeepers;

public class GetKeepersQuery : IRequest<List<KeeperSimpleDto>>
{
}
