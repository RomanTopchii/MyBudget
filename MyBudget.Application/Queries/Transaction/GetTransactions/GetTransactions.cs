using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Transaction.GetTransactions;

public class GetTransactions : IRequest<List<TransactionDto>>
{
}