using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.Account.SaveAccount;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class AccountEndpoints : IApiRoute
{
    private readonly string _name = "Account";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{this._name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = this._name } }
            });

        group.MapPost("SaveAccount", (SaveAccountCommand model, IMediator mediator) =>
            mediator.Send(model, default));
    }
}
