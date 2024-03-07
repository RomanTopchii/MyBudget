using MediatR;

namespace MyBudget.Application.Commands.Holder.DeleteHolder;

public class DeleteHolderCommand : IRequest
{
    public Guid Id { get; set; }
}
