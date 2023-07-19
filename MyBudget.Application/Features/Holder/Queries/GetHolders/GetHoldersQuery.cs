using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Features.Holder.Queries.GetHolders;

public class GetHoldersQuery : IRequest<List<HolderSimpleDto>>
{
}
