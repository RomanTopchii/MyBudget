using MediatR;

namespace MyBudget.Application.Commands.Keeper.DeleteKeeper;

public class DeleteKeeperCommand : IRequest
{
    public Guid Id { get; set; }
}
