using FastEndpoints;
using MediatR;
using MyBudget.Application.Commands.Holder.DeleteHolder;

namespace MyBudget.WebApi.Endpoints.Holder;

public class DeleteHolderEndpoint : Endpoint<DeleteHolderCommand>
{
    private readonly IMediator _mediator;

    public DeleteHolderEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Holder/DeleteHolder");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteHolderCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
