using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.Holder.DeleteHolder;
using MyBudget.Application.Commands.Holder.SaveHolder;
using MyBudget.Application.Queries.Holder.GetHolders;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class HolderEndpoints : IApiRoute
{
    private readonly string _name = "Holder";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{this._name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = this._name } }
            });

        group.MapDelete("DeleteHolder", (Guid id, IMediator mediator) =>
            mediator.Send(new DeleteHolderCommand(Id: id), default));

        group.MapPost("SaveHolder", (SaveHolderCommand model, IMediator mediator) =>
            mediator.Send(model, default));
        
        group.MapGet("GetHolders", (IMediator mediator) =>
            mediator.Send(new GetHoldersQuery(), default));
    }
}
