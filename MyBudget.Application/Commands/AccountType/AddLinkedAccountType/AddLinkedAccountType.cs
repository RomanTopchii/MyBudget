using MediatR;

namespace MyBudget.Application.Commands.AccountType.AddLinkedAccountType;

public record AddLinkedAccountType(
    Guid AccountTypeId,
    Guid LinkedAccountTypeId
) : IRequest;