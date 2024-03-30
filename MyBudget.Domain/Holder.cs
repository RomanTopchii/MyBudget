using MyBudget.Domain.Attributes;
using MyBudget.Domain.Core;

namespace MyBudget.Domain;

[Auditable]
public class Holder : DictionaryEntity
{
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
