using System.Runtime.Serialization;
using MyBudget.Application.Domain;
using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class AccountTypeDoesNotCorrelateParentTypeException : Exception
{
    public AccountTypeDoesNotCorrelateParentTypeException()
        : base("AccountType does not correlate with parent account type")
    {
    }

    public AccountTypeDoesNotCorrelateParentTypeException(string message)
        : base(message)
    {
    }

    public AccountTypeDoesNotCorrelateParentTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AccountTypeDoesNotCorrelateParentTypeException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
