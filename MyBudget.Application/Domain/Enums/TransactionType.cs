namespace MyBudget.Application.Domain.Enums;

public enum TransactionType
{
    Unknown = 0, // for incomplete transaction
    Income = 1, // from Income
    Expense = 2, // to Expense
    Transfer = 3, // Money<->Money, Money<->Debtors, Money<->Creditors, Debtors<->Creditors
    InitialBalance = 4, // set manually. should not be changed in future
    Other = 5
}
