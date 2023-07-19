using MediatR;

namespace MyBudget.Application.Features.Holder.Commands.DeleteHolder;

public class DeleteHolderCommand : IRequest
{
    public Guid Id { get; set; }
}
