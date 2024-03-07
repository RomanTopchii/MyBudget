using MediatR;

namespace MyBudget.Application.Commands.Account.SaveAccount;

public class SaveAccountCommand : IRequest
{
    public Guid? Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }

    public Guid TypeId { get; set; }
    
    public Guid? CurrencyId { get; set; }

    public Guid? HolderId { get; set; }

    public Guid? KeeperId { get; set; }

    public Guid? LinkedAccountId { get; set; }
}
