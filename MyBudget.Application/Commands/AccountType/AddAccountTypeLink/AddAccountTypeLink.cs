using MediatR;

namespace MyBudget.Application.Commands.AccountType.AddAccountTypeLink;

public record AddAccountTypeLink(
    Guid ChildId,
    Guid AncestorId
) : IRequest;