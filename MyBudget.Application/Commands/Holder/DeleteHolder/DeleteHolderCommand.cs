using MediatR;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public record DeleteHolderCommand(Guid Id) : IRequest;
