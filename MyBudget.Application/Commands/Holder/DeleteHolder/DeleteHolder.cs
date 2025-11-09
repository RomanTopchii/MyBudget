using MediatR;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public record DeleteHolder(Guid Id) : IRequest;
