using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Transaction.DeleteTransaction;
using MyBudget.Application.Commands.Transaction.SaveTransaction;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Transaction.GetTransactions;

namespace MyBudget.WebApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class TransactionController (IMediator mediator): ControllerBase
{
    [HttpDelete]
    public Task DeleteTransaction(Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new DeleteTransactionCommand(Id: id), cancellationToken);
    
    [HttpPost]
    public Task SaveTransaction(SaveTransactionCommand model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<TransactionDto>> GetTransactions(CancellationToken cancellationToken) =>
        mediator.Send(new GetTransactionsQuery(), cancellationToken);
}