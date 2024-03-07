using System.Runtime.Serialization;
using MyBudget.Domain;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class CurrencyWithSameCodeAlreadyExistsException: Exception
{
    public CurrencyWithSameCodeAlreadyExistsException()
        : base()
    {
    }

    public CurrencyWithSameCodeAlreadyExistsException(string message)
        : base(message)
    {
    }

    public CurrencyWithSameCodeAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CurrencyWithSameCodeAlreadyExistsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public CurrencyWithSameCodeAlreadyExistsException(Currency currency)
        : base($"Currency with the same code \"{currency.Code}\" already exists")
    {
        
    }
}
