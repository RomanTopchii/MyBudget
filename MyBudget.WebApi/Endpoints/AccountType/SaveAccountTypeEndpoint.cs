using FastEndpoints;
using MediatR;
using MyBudget.Application.Features.AccountType.Commands;

namespace MyBudget.WebApi.Endpoints.AccountType;

public class SaveAccountTypeEndpoint : Endpoint<SaveAccountTypeCommand>
{
    private readonly IMediator _mediator;

    public SaveAccountTypeEndpoint(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("AccountType/SaveAccountType");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SaveAccountTypeCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
    }
}
