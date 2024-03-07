using FastEndpoints;
using MediatR;
using MyBudget.Application.Commands.Holder.SaveHolder;

namespace MyBudget.WebApi.Endpoints.Holder;

public class SaveHolderEndpoint : Endpoint<SaveHolderCommand>
{
    private readonly IMediator _mediator;

    public SaveHolderEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Holder/SaveHolder");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveHolderCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
