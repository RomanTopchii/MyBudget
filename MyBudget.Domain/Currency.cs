using MyBudget.Domain.Core;

namespace MyBudget.Domain;

public class Currency : DictionaryEntity
{
    public string Code { get; set; } = string.Empty;
    
    public int Iso4217 { get; set; }

    public bool IsAccounting { get; set; }
    
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
