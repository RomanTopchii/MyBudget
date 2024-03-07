namespace MyBudget.Application.Domain.Enums;

public enum TransactionItemType
{
    Debit = 0,
    Credit = 1
}


static class TransactionItemTypeMethods
{
    public static string GetString(this TransactionItemType s1)
    {
        switch (s1)
        {
            case TransactionItemType.Debit:
                return "Debit";
            case TransactionItemType.Credit:
                return "Credit";
            default:
                return "Out of enumeration";
        }
    }
}