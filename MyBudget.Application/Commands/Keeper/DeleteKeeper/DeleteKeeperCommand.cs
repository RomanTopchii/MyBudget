using MediatR;

namespace MyBudget.Application.Commands.Keeper.DeleteKeeper;

public record DeleteKeeperCommand(Guid Id) : IRequest;
