using FastEndpoints;
using MediatR;
using MyBudget.Application.Commands.Currency.SaveCurrency;

namespace MyBudget.WebApi.Endpoints.Currency;

public class SaveCurrencyEndpoint : Endpoint<SaveCurrencyCommand>
{
    private readonly IMediator _mediator;

    public SaveCurrencyEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Currency/SaveCurrency");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveCurrencyCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
