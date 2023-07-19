using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Keeper.Commands;
using MyBudget.Application.Features.Keeper.Commands.SaveKeeper;
using MyBudget.Application.Features.Keeper.Queries.GetKeepers;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.WebApi.Endpoints.Keeper;

public class GetKeepersEndpoint : Endpoint<GetKeepersQuery, List<KeeperSimpleDto>>
{
    private readonly IMediator _mediator;

    public GetKeepersEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("Keeper/GetKeepers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetKeepersQuery req, CancellationToken ct)
    {
        var result = await _mediator.Send(req, ct);
        await this.SendAsync(result);
    }
}
