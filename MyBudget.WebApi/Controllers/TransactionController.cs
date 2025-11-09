using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Transaction.DeleteTransaction;
using MyBudget.Application.Commands.Transaction.SaveTransaction;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Transaction.GetTransactions;

namespace MyBudget.WebApi.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionController(IMediator mediator) : ControllerBase
{
    [HttpDelete]
    public Task DeleteTransaction(Guid id, CancellationToken cancellationToken)
    {
        return mediator.Send(new DeleteTransaction(id), cancellationToken);
    }

    [HttpPost]
    public Task SaveTransaction(SaveTransaction model, CancellationToken cancellationToken)
    {
        return mediator.Send(model, cancellationToken);
    }

    [HttpGet]
    public Task<List<TransactionDto>> GetTransactions(CancellationToken cancellationToken)
    {
        return mediator.Send(new GetTransactions(), cancellationToken);
    }
}