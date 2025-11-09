using MediatR;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Keeper.SaveKeeper;

public record SaveKeeper(Guid? Id, bool Active, string Name, KeeperType Type) : IRequest;
