using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Holder.GetHolderById;

public record GetHolderByIdQuery(Guid Id) : IRequest<HolderSimpleDto>;