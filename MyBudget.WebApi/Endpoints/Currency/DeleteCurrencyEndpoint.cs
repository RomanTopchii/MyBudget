using FastEndpoints;
using MediatR;
using MyBudget.Application.Commands.Currency.DeleteCurrency;

namespace MyBudget.WebApi.Endpoints.Currency;

public class DeleteCurrencyEndpoint : Endpoint<DeleteCurrencyCommand>
{
    private readonly IMediator _mediator;

    public DeleteCurrencyEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Currency/DeleteCurrency");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCurrencyCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
