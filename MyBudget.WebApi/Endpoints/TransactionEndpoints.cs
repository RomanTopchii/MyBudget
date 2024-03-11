using MediatR;
using MyBudget.Application.Commands.Transaction.DeleteTransaction;
using MyBudget.Application.Commands.Transaction.SaveTransaction;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Transaction.GetTransactions;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class TransactionEndpoints : IApiRoute
{
    private const string GroupName = "Transaction";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapDelete("DeleteTransaction", DeleteTransaction)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapPost("SaveTransaction", SaveTransaction)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapGet("GetTransactions", GetTransactions)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task DeleteTransaction(Guid id, IMediator mediator) =>
        mediator.Send(new DeleteTransactionCommand(Id: id), default);

    private Task SaveTransaction(SaveTransactionCommand model, IMediator mediator) =>
        mediator.Send(model, default);

    private Task<List<TransactionDto>> GetTransactions(IMediator mediator) =>
        mediator.Send(new GetTransactionsQuery(), default);
}
