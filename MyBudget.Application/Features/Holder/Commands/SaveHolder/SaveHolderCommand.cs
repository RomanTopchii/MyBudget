using MediatR;
using MyBudget.Application.Domain.Enums;

namespace MyBudget.Application.Features.Holder.Commands.SaveHolder;

public class SaveHolderCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;
}
