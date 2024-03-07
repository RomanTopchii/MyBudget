using FastEndpoints;
using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Transaction.GetTransactions;

namespace MyBudget.WebApi.Endpoints.Keeper;

public class GetTransactionsEndpoint : Endpoint<EmptyRequest, List<TransactionDto>>
{
    private readonly IMediator _mediator;

    public GetTransactionsEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("Transaction/GetTransactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetTransactionsQuery(), ct);
        await this.SendAsync(result);
    }
}
