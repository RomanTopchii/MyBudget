using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Transaction.ApplyApprovedTransactions;

public record ApplyApprovedTransactionsCommandHandler(
    ITransactionRepository TransactionRepository,
    IUnitOfWork UnitOfWork) 
    : IRequestHandler<ApplyApprovedTransactionsCommand>
{
    public async Task Handle(ApplyApprovedTransactionsCommand request, CancellationToken cancellationToken)
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
