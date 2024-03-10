using MediatR;
using MyBudget.Application.Exceptions;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Transaction.DeleteTransaction;

public record DeleteTransactionCommandHandler(
        ITransactionRepository TransactionRepository,
        IRepository<TransactionItem> TransactionItemRepository,
        IUnitOfWork UnitOfWork)
    : IRequestHandler<DeleteTransactionCommand>
{
    public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
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
