using MediatR;

namespace MyBudget.Application.Commands.AccountType.DeleteAccountTypeLink;

public record DeleteAccountTypeLink(
    Guid ChildId,
    Guid AncestorId
) : IRequest;