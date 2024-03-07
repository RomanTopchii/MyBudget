using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Features.Transaction.Queries.GetTransactions;

public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransactionsHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<List<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        return (await this._unitOfWork.TransactionRepository.GetAllAsync())
            .Select(x => new TransactionDto(x))
            .ToList();
    }
}
