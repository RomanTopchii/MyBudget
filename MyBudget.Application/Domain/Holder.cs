using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Domain;

public class Holder : DictionaryEntity
{
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
