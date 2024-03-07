using FastEndpoints;
using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Currency.GetCurrencies;

namespace MyBudget.WebApi.Endpoints.Currency;

public class GetCurrenciesEndpoint : Endpoint<EmptyRequest, List<CurrencySimpleDto>>
{
    private readonly IMediator _mediator;

    public GetCurrenciesEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("Currency/GetCurrencies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCurrenciesQuery(), ct);
        await this.SendAsync(result);
    }
}
