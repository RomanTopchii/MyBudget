using MediatR;

namespace MyBudget.Application.Commands.Transaction.DeleteTransaction;

public record DeleteTransactionCommand(Guid Id) : IRequest;
