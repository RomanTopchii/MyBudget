using MediatR;

namespace MyBudget.Application.Commands.Account.SaveAccount;

public record SaveAccountCommand(
    Guid? Id,
    bool Active,
    string Name,
    Guid? ParentId,
    Guid TypeId,
    Guid? CurrencyId,
    Guid? HolderId,
    Guid? KeeperId,
    Guid? LinkedAccountId
) : IRequest;
