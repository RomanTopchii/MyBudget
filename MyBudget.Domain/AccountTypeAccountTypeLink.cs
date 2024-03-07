using MyBudget.Domain.Core;

namespace MyBudget.Domain;

public class AccountTypeAccountTypeLink : BaseEntity
{
    public Guid AncestorId { get; set; }

    public AccountType Ancestor { get; set; } = new();

    public Guid ChildId { get; set; }

    public AccountType Child { get; set; } = new();
}
