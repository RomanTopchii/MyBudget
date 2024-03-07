using System.Runtime.Serialization;

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
