using MediatR;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Features.Keeper.Commands.SaveKeeper;

public class SaveKeeperCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public KeeperType Type { get; set; }
}
