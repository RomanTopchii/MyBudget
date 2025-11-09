using MyBudget.Application.Interfaces.Dto.Core;
using MyBudget.Domain;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Interfaces.Dto;

public class AccountTypeRichDto : DictionaryEntityDto
{
    public Classification? Classification { get; set; }

    public bool HasCurrency { get; set; }

    public bool HasHolder { get; set; }

    public bool HasKeeper { get; set; }

    public AccountTypeNamedDto? LinkedAccountType { get; set; }

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

    public List<AccountTypeNamedDto> Children { get; set; }

    public List<AccountTypeNamedDto> Ancestors { get; set; }

    public AccountTypeRichDto(AccountType domain) : base(domain)
    {
        this.Classification = domain.Classification;
        this.HasCurrency = domain.HasCurrency;
        this.HasHolder = domain.HasHolder;
        this.HasKeeper = domain.HasKeeper;
        this.LinkedAccountType = domain.LinkedAccountType != null
            ? new AccountTypeNamedDto(domain.LinkedAccountType!)
            : null;
        this.HasInitialBalance = domain.HasInitialBalance;
        this.CalcFullTimeBalance = domain.CalcFullTimeBalance;
        this.CanBeDeleted = domain.CanBeDeleted;
        this.CanChangeActiveStatus = domain.CanChangeActiveStatus;
        this.CanBeRenamed = domain.CanBeRenamed;
        this.CanBeCreatedByUser = domain.CanBeCreatedByUser;
        this.CheckAmountBeforeDeactivate = domain.CheckAmountBeforeDeactivate;
        this.AllowsTransactions = domain.AllowsTransactions;
        this.KeeperGroup = domain.KeeperGroup;
        this.Priority = domain.Priority;
        this.Children = domain.AncestorAccountTypeLinks.Select(x => new AccountTypeNamedDto(x.Child)).ToList();
        this.Ancestors = domain.ChildAccountTypeLinks.Select(x => new AccountTypeNamedDto(x.Ancestor)).ToList();

    }
}