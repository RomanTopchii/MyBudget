using MediatR;

namespace MyBudget.Application.Commands.Transaction.DeleteTransaction;

public record DeleteTransaction(Guid Id) : IRequest;
