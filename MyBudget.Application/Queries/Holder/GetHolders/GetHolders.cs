using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Holder.GetHolders;

public record GetHolders : IRequest<List<HolderSimpleDto>>;
