using System.Runtime.Serialization;
using MyBudget.Domain;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException
    : Exception
{
    public CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException()
        : base("Current accounting currency already has accounts with transactions")
    {
    }

    public CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException(string message)
        : base(message)
    {
    }

    public CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CurrentAccountingCurrencyAlreadyAccountsWithTransactionsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
