namespace MyBudget.Infrastructure.Persistence.Migrations.Queries;

public static class InitiateAccountType
{
    public static string Query = @"
INSERT INTO app.AccountType (
                         id,
                         name,
                         classification,
                         hasCurrency,
                         hasHolder,
                         hasKeeper,
                         linkedAccountTypeId,
                         hasInitialBalance,
                         calcFullTimeBalance,
                         canBeDeleted,
                         canChangeActiveStatus,
                         canBeRenamed,
                         canBeCreatedByUser,
                         checkAmountBeforeDeactivate,
                         allowsTransactions,
                         keeperGroup,
                         priority,
                         active,
                         createDate,
                         createdBy,
                         modifyDate,
                         modifiedBy      
)
VALUES
('00000000-0000-0000-0000-000000000001','Accounting',0,0,0,0,null,0,0,0,0,0,0,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000002','Creditors consolidation',2,0,0,0,null,0,1,0,0,0,0,0,1,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000003','Creditor',2,1,1,1,null,1,1,1,1,1,1,1,1,3,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000004','Money consolidation',1,0,0,0,null,0,1,0,0,0,0,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000005','Credit Card',1,1,1,1,'00000000-0000-0000-0000-000000000003',1,1,1,1,1,1,1,1,2,3,1,null,null,null,null),
('00000000-0000-0000-0000-000000000006','Debit Card',1,1,1,1,null,1,1,1,1,1,1,1,1,2,2,1,null,null,null,null),
('00000000-0000-0000-0000-000000000007','Cash',1,1,1,1,null,1,1,1,1,1,1,1,1,1,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000008','Debtors consolidation',1,0,0,0,null,0,1,0,0,0,0,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000009','Debtor',1,1,1,1,null,1,1,1,1,1,1,1,1,3,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000010','Income consolidation',1,1,0,0,null,0,0,0,0,0,0,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000011','Expense consolidation',2,1,0,0,null,0,0,0,0,0,0,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000012','Capital consolidation',2,1,0,0,null,0,1,0,0,0,0,0,1,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000013','Liabilities category consolidation',1,1,0,0,null,0,0,1,1,1,1,0,0,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000014','Assets category consolidation',2,1,0,0,null,0,0,1,1,1,1,0,0,0,2,1,null,null,null,null),
('00000000-0000-0000-0000-000000000015','Liabilities category',1,1,0,0,null,0,0,1,1,1,1,0,1,0,1,1,null,null,null,null),
('00000000-0000-0000-0000-000000000016','Assets category',2,1,0,0,null,0,0,1,1,1,1,0,1,0,2,1,null,null,null,null),
('00000000-0000-0000-0000-000000000017','Expense before accounting period',1,1,0,0,null,0,0,0,1,0,0,0,1,0,1,1,null,null,null,null)
";
}