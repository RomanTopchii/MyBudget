using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Transaction.Commands.SaveTransaction;

namespace MyBudget.WebApi.Endpoints.Transaction;

public class SaveTransactionEndpoint : Endpoint<SaveTransactionCommand>
{
    private readonly IMediator _mediator;

    public SaveTransactionEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Transaction/SaveTransaction");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveTransactionCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
