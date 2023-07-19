using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Currency.Commands.SaveCurrency;
using MyBudget.Application.Features.Currency.Commands.SetAccountingCurrency;

namespace MyBudget.WebApi.Endpoints.Currency;

public class SetAccountingCurrencyEndpoint : Endpoint<SetAccountingCurrencyCommand>
{
    private readonly IMediator _mediator;

    public SetAccountingCurrencyEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Currency/SetAccountingCurrency");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SetAccountingCurrencyCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
