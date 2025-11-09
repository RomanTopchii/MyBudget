using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Transaction.ApplyApprovedTransactions;

public record ApplyApprovedTransactionsHandler(
    ITransactionRepository TransactionRepository,
    IUnitOfWork UnitOfWork) 
    : IRequestHandler<ApplyApprovedTransactions>
{
    public async Task Handle(ApplyApprovedTransactions request, CancellationToken cancellationToken)
    {
        var approvedTransactions = this.TransactionRepository.Query()
            .Where(x => x.Status == TransactionStatus.Approved);

        foreach (var transaction in approvedTransactions)
        {
            transaction.Status = TransactionStatus.Applied;
        }

        this.UnitOfWork.Complete();
    }
}
