using MediatR;
using MyBudget.Application.Domain;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Transaction.Commands.SaveTransaction;

public class SaveTransactionCommandHandler : IRequestHandler<SaveTransactionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveTransactionCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveTransactionCommand request, CancellationToken cancellationToken)
    {
        Domain.Transaction? transaction = null;
        if (request.Id != null)
        {
            transaction = await this._unitOfWork.TransactionRepository.GetByIdAsync((Guid)request.Id);
        }

        if (transaction == null)
        {
            transaction = new Domain.Transaction();
            await this._unitOfWork.TransactionRepository.AddAsync(transaction);
        }

        transaction.Id = request.Id ?? Guid.NewGuid();
        transaction.Active = true;
        transaction.Type = request.Type;
        transaction.Status = request.Status;
        transaction.Comment = string.IsNullOrWhiteSpace(request.Comment) ? request.Comment : null;
        
        //Update transaction items
        var itemsToUpdate = transaction.TransactionItems.Where(x =>
                request.TransactionItems.Select(ti => ti.Id).Contains(x.Id))
            .ToList();
        foreach (var itemToUpdate in itemsToUpdate)
        {
            var itemFromRequest = request.TransactionItems.Single(x => x.Id != null &&
                                                                       itemsToUpdate.Select(ti => ti.Id)
                                                                           .Contains((Guid)x.Id));
            itemToUpdate.AccountId = itemFromRequest.AccountId;
            itemToUpdate.Amount = itemFromRequest.Amount;
        }
        
        //Add transaction items
        foreach (var newItemFromRequest in request.TransactionItems.Where(x =>
                     x.Id == null || !transaction.TransactionItems.Select(ti => ti.Id).Contains((Guid)x.Id)))
        {
            var item = new TransactionItem
            {
                Id = newItemFromRequest.Id ?? Guid.NewGuid(),
                AccountId = newItemFromRequest.AccountId,
                Amount = newItemFromRequest.Amount,
                Transaction = transaction
            };
            await this._unitOfWork.TransactionItemRepository.AddAsync(item);
        }

        //Delete transaction items
        var itemsToDelete = transaction.TransactionItems.Where(x =>
                !request.TransactionItems.Select(ti => ti.Id).Contains(x.Id))
            .ToList();
        foreach (var item in itemsToDelete)
        {
            transaction.TransactionItems.Remove(item);
            await this._unitOfWork.TransactionItemRepository.RemoveAsync(item);
        }

        this._unitOfWork.Complete();
    }
}
