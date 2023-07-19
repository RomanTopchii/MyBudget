using System.Runtime.Serialization;
using MyBudget.Application.Domain;

namespace MyBudget.Application.Exceptions;

[Serializable]
public class KeeperUsedInAccountException
    : Exception
{
    public KeeperUsedInAccountException()
        : base()
    {
    }

    public KeeperUsedInAccountException(string message)
        : base(message)
    {
    }

    public KeeperUsedInAccountException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public KeeperUsedInAccountException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public KeeperUsedInAccountException(Guid keeperId)
        : base($"Keeper with id = \"{keeperId}\" already in account")
    {
    }
}
