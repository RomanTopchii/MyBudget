using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Features.Transaction.Queries.GetTransactions;

public class GetTransactionsQuery : IRequest<List<TransactionDto>>
{
}
