using MediatR;
using MyBudget.Application.Domain.Enums;

namespace MyBudget.Application.Features.Keeper.Commands;

public class SaveKeeperCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public KeeperType Type { get; set; }
}
