using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Keeper.Commands.DeleteKeeper;

namespace MyBudget.WebApi.Endpoints.Keeper;

public class DeleteKeeperEndpoint : Endpoint<DeleteKeeperCommand>
{
    private readonly IMediator _mediator;

    public DeleteKeeperEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Keeper/DeleteKeeper");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteKeeperCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
