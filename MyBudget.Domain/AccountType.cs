using MyBudget.Domain.Attributes;
using MyBudget.Domain.Core;
using MyBudget.Domain.Enums;

namespace MyBudget.Domain;

[Auditable]
public class AccountType : DictionaryEntity
{
    public Classification? Classification { get; set; }

    public bool HasCurrency { get; set; }

    public bool HasHolder { get; set; }

    public bool HasKeeper { get; set; }

    public bool HasLinkedAccount { get; set; }

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

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<AccountTypeAccountTypeLink> AncestorAccountTypeLinks { get; set; } = new List<AccountTypeAccountTypeLink>();

    public virtual ICollection<AccountTypeAccountTypeLink> ChildAccountTypeLinks { get; set; } = new List<AccountTypeAccountTypeLink>();
}
