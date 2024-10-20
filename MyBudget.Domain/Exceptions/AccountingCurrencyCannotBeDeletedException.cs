using System.Runtime.Serialization;

namespace MyBudget.Domain.Exceptions;

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
        : base($"Accounting currency \"{currency.Code}\" can not be deleted")
    {
    }
}
