using System.Runtime.Serialization;
using MyBudget.Application.Domain;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class ObjectUsedInAccountException<T>
    : Exception
{
    public ObjectUsedInAccountException()
        : base()
    {
    }

    public ObjectUsedInAccountException(string message)
        : base(message)
    {
    }

    public ObjectUsedInAccountException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ObjectUsedInAccountException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public ObjectUsedInAccountException(Guid objectid)
        : base($"{typeof(T).Name} with id = \"{objectid}\" already in account")
    {
    }
}
