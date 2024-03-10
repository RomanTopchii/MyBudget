using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.Transaction.DeleteTransaction;
using MyBudget.Application.Commands.Transaction.SaveTransaction;
using MyBudget.Application.Queries.Transaction.GetTransactions;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class TransactionEndpoints : IApiRoute
{
    private readonly string _name = "Transaction";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{this._name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = this._name } }
            });
        
        group.MapDelete("DeleteTransaction", (Guid id, IMediator mediator) =>
            mediator.Send(new DeleteTransactionCommand(Id: id), default));
        
        group.MapPost("SaveTransaction", (SaveTransactionCommand model, IMediator mediator) =>
            mediator.Send(model, default));

        group.MapGet("GetTransactions", (IMediator mediator) =>
            mediator.Send(new GetTransactionsQuery(), default));
    }
}
