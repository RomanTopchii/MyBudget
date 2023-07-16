using System.Runtime.Serialization;
using MyBudget.Application.Domain.Core;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class ObjectWithSameNameAlreadyExistsException<T>: Exception
{
    public ObjectWithSameNameAlreadyExistsException()
        : base()
    {
    }

    public ObjectWithSameNameAlreadyExistsException(string message)
        : base(message)
    {
    }

    public ObjectWithSameNameAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ObjectWithSameNameAlreadyExistsException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public ObjectWithSameNameAlreadyExistsException(DictionaryEntity dictionaryEntity)
        : base($"{typeof(T).Name} with the same name \"{dictionaryEntity.Name}\" already exists")
    {
        
    }
}
