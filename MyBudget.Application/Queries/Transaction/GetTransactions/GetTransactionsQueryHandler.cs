using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Transaction.GetTransactions;

public record GetTransactionsHandler(ITransactionRepository TransactionRepository)
    : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
{
    public async Task<List<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        return (await this.TransactionRepository.GetAllAsync())
            .Select(x => new TransactionDto(x))
            .ToList();
    }
}
