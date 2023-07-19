using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Holder.Queries.GetHolders;
using MyBudget.Application.Features.Keeper.Queries.GetKeepers;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.WebApi.Endpoints.Holder;

public class GetHoldersEndpoint : Endpoint<EmptyRequest, List<HolderSimpleDto>>
{
    private readonly IMediator _mediator;

    public GetHoldersEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("Holder/GetHolders");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetHoldersQuery(), ct);
        await this.SendAsync(result);
    }
}
