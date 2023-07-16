using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Keeper.Commands;

namespace MyBudget.WebApi.Endpoints.Keeper;

public class SaveKeeperEndpoint : Endpoint<SaveKeeperCommand>
{
    private readonly IMediator _mediator;

    public SaveKeeperEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Keeper/SaveKeeper");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveKeeperCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    } 
}