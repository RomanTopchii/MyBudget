using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.AccountType.SaveAccountType;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class AccountTypeEndpoints : IApiRoute
{
    private readonly string _name = "AccountType";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{this._name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = this._name } }
            });

        group.MapPost("SaveAccountType", (SaveAccountTypeCommand model, IMediator mediator) =>
            mediator.Send(model, default));
    }
}
