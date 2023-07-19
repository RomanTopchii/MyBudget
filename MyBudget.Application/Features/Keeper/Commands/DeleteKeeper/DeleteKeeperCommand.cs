using MediatR;

namespace MyBudget.Application.Features.Keeper.Commands.DeleteKeeper;

public class DeleteKeeperCommand : IRequest
{
    public Guid Id { get; set; }
}
