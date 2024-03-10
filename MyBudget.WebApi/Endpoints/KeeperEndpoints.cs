using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.Keeper.DeleteKeeper;
using MyBudget.Application.Commands.Keeper.SaveKeeper;
using MyBudget.Application.Queries.Keeper.GetKeepers;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class KeeperEndpoints : IApiRoute
{
    private readonly string _name = "Keeper";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{this._name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = this._name } }
            });

        group.MapDelete("DeleteKeeper", (Guid id, IMediator mediator) =>
            mediator.Send(new DeleteKeeperCommand(Id: id), default));

        group.MapPost("SaveKeeper", (SaveKeeperCommand model, IMediator mediator) =>
            mediator.Send(model, default));
        
        group.MapGet("GetKeepers", (IMediator mediator) =>
            mediator.Send(new GetKeepersQuery(), default));
    }
}
