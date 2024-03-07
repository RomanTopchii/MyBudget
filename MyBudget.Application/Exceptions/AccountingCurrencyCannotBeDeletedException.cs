using System.Runtime.Serialization;
using MyBudget.Domain;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class AccountingCurrencyCannotBeDeletedException
    : Exception
{
    public AccountingCurrencyCannotBeDeletedException()
        : base()
    {
    }

    public AccountingCurrencyCannotBeDeletedException(string message)
        : base(message)
    {
    }

    public AccountingCurrencyCannotBeDeletedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AccountingCurrencyCannotBeDeletedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public AccountingCurrencyCannotBeDeletedException(Currency currency)
        : base($"Accounting currency \"{currency.Name}\" can not be deleted")
    {
    }
}
