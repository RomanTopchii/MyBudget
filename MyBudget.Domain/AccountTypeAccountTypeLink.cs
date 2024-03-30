using MyBudget.Domain.Attributes;
using MyBudget.Domain.Core;

namespace MyBudget.Domain;

[Auditable]
public class AccountTypeAccountTypeLink : BaseEntity
{
    public Guid AncestorId { get; set; }

    public virtual AccountType Ancestor { get; set; } = new();

    public Guid ChildId { get; set; }

    public virtual AccountType Child { get; set; } = new();
}
