using MediatR;

namespace MyBudget.Application.Commands.Keeper.DeleteKeeper;

public record DeleteKeeper(Guid Id) : IRequest;
