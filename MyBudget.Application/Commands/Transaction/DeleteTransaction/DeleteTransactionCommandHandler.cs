using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;
using MyBudget.Domain.Enums;
using MyBudget.Domain.Exceptions;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Commands.Transaction.DeleteTransaction;

public record DeleteTransactionHandler(
        ITransactionRepository TransactionRepository,
        IRepository<TransactionItem> TransactionItemRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<DeleteTransaction>
{
    public async Task Handle(DeleteTransaction request, CancellationToken cancellationToken)
    {
        var transaction = await this.TransactionRepository.GetByIdAsync(request.Id) ??
                          throw new ObjectNotFoundException<Domain.Transaction>(request.Id);

        if (transaction.Status == TransactionStatus.Archived)
        {
            throw new Exception("Transaction already applied");
        }

        if (transaction.TransactionItems.Any())
        {
            this.TransactionItemRepository.RemoveRange(transaction.TransactionItems);
        }

        this.TransactionRepository.Remove(transaction);
        this.UnitOfWork.Complete();
    }
}
