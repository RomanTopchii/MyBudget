using MediatR;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Keeper.SaveKeeper;

public record SaveKeeperCommand(Guid? Id, bool Active, string Name, KeeperType Type) : IRequest;
