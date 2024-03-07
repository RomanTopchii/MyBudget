using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Holder.GetHolders;

public class GetHoldersQuery : IRequest<List<HolderSimpleDto>>
{
}
