using MediatR;

namespace MyBudget.Application.Commands.Holder.SaveHolder;

public class SaveHolderCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;
}
