using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Domain;

public class AccountTypeAccountTypeLink : BaseEntity
{
    public Guid AncestorId { get; set; }

    public AccountType Ancestor { get; set; } = new();

    public Guid ChildId { get; set; }

    public AccountType Child { get; set; } = new();
}
