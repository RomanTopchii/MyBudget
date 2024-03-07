using MyBudget.Domain.Core;
using MyBudget.Domain.Enums;

namespace MyBudget.Domain;

public class Keeper : DictionaryEntity
{
    public KeeperType Type { get; set; } = KeeperType.Bank;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
