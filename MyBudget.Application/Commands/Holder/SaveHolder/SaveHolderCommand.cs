using MediatR;

namespace MyBudget.Application.Commands.Holder.SaveHolder;

public record SaveHolderCommand(Guid? Id, bool Active, string Name) : IRequest;
