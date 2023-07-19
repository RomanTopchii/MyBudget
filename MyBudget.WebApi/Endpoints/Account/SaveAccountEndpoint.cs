using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.Account.Commands.SaveAccount;

namespace MyBudget.WebApi.Endpoints.Account;

public class SaveAccountEndpoint : Endpoint<SaveAccountCommand>
{
    private readonly IMediator _mediator;

    public SaveAccountEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("Account/SaveAccount");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveAccountCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
