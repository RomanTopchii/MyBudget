using MyBudget.Domain.Core;

namespace MyBudget.Domain;

public class Holder : DictionaryEntity
{
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
