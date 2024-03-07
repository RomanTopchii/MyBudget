using MediatR;
using MyBudget.Domain.Enums;
using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Features.AccountType.Commands.SaveAccountType;

public class SaveAccountTypeCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;

    public Classification? Classification { get; set; }

    public bool HasCurrency { get; set; }

    public bool HasHolder { get; set; }

    public bool HasKeeper { get; set; }

    public bool HasInitialBalance { get; set; }

    public bool CalcFullTimeBalance { get; set; }

    public bool CanBeDeleted { get; set; }

    public bool CanChangeActiveStatus { get; set; }

    public bool CanBeRenamed { get; set; }

    public bool CanBeCreatedByUser { get; set; }

    public bool CheckAmountBeforeDeactivate { get; set; }

    public bool AllowsTransactions { get; set; }

    public KeeperGroup KeeperGroup { get; set; }

    public int Priority { get; set; }

    public List<IdentifiableDto> ParentTypes { get; set; } = new List<IdentifiableDto>();
}
