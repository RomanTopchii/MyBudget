using MyBudget.Application.Domain.Core;
using MyBudget.Application.Domain.Enums;

namespace MyBudget.Application.Domain;

public class Keeper : DictionaryEntity
{
    public KeeperType Type { get; set; } = KeeperType.Bank;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
