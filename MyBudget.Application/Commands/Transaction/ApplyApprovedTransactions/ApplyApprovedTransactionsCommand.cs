using MediatR;

namespace MyBudget.Application.Commands.Transaction.ApplyApprovedTransactions;

public record ApplyApprovedTransactionsCommand(): IRequest;
