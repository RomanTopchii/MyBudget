using System.Runtime.Serialization;
using MyBudget.Application.Domain;
using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class CurrencyWithSameIso4217AlreadyExistsException: Exception
{
    public CurrencyWithSameIso4217AlreadyExistsException()
        : base()
    {
    }

    public CurrencyWithSameIso4217AlreadyExistsException(string message)
        : base(message)
    {
    }

    public CurrencyWithSameIso4217AlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CurrencyWithSameIso4217AlreadyExistsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public CurrencyWithSameIso4217AlreadyExistsException(int iso4217)
        : base($"Currency with the same Iso4217 \"{iso4217.ToString()}\" already exists")
    {
        
    }
}
