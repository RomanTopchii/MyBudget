using System.Runtime.Serialization;

namespace MyBudget.Domain.Exceptions;

[Serializable]
public class DynamicAccountException : Exception
{
    public DynamicAccountException()
        : base()
    {
    }

    public DynamicAccountException(string message)
        : base(message)
    {
    }

    public DynamicAccountException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DynamicAccountException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
