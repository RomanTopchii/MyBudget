using MediatR;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.AccountType.SaveAccountType;

public record SaveAccountTypeCommand(
    Guid? Id,
    bool Active,
    string Name,
    Classification? Classification,
    bool HasCurrency,
    bool HasHolder,
    bool HasKeeper,
    bool HasInitialBalance,
    bool CalcFullTimeBalance,
    bool CanBeDeleted,
    bool CanChangeActiveStatus,
    bool CanBeRenamed,
    bool CanBeCreatedByUser,
    bool CheckAmountBeforeDeactivate,
    bool AllowsTransactions,
    KeeperGroup KeeperGroup,
    int Priority,
    List<Guid> ParentTypes
) : IRequest;
