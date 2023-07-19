using System.Runtime.Serialization;
using MyBudget.Application.Domain;
using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class AccountingCurrencyCannotBeDeactivatedException : Exception
{
    public AccountingCurrencyCannotBeDeactivatedException()
        : base("Cannot deactivate accounting currency")
    {
    }

    public AccountingCurrencyCannotBeDeactivatedException(string message)
        : base(message)
    {
    }

    public AccountingCurrencyCannotBeDeactivatedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AccountingCurrencyCannotBeDeactivatedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
