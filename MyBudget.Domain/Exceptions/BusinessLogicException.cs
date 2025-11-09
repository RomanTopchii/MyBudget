namespace MyBudget.Domain.Exceptions;

[Serializable]
public class BusinessLogicException : Exception
{
    public BusinessLogicException(string message): base(message)
    {
    }
}