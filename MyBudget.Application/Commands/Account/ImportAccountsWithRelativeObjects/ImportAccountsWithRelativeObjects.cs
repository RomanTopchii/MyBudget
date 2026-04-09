using MediatR;

namespace MyBudget.Application.Commands.Account.ImportAccountsWithRelativeObjects;

public record ImportAccountsWithRelativeObjects(List<ImportAccount> List) : IRequest;


public class ImportAccount
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public ImportHolder? Holder { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public ImportKeeper? Keeper { get; set; }
    public Guid? LinkedAccountId { get; set; }
    public ImportCurrency? Currency { get; set; }
    public Guid? ParentId { get; set; }
}

public class ImportHolder
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class ImportKeeper
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
}

public class ImportCurrency
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public int Iso4217 { get; set; }
    public bool IsAccounting { get; set; }
}