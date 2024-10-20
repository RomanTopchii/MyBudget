using System.Runtime.Serialization;

namespace MyBudget.Domain.Exceptions.Generic;

[Serializable]
public class ObjectNotFoundException<T>
    : Exception
{
    public ObjectNotFoundException()
        : base()
    {
    }

    public ObjectNotFoundException(string message)
        : base(message)
    {
    }

    public ObjectNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ObjectNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public ObjectNotFoundException(Guid id)
        : base($"{typeof(T).Name} with id = \"{id}\" was not found")
    {
    }
}
