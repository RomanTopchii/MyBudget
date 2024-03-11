using MediatR;
using MyBudget.Application.Commands.Keeper.DeleteKeeper;
using MyBudget.Application.Commands.Keeper.SaveKeeper;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Keeper.GetKeepers;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class KeeperEndpoints : IApiRoute
{
    private const string GroupName = "Keeper";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapDelete("DeleteKeeper", DeleteKeeper)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapPost("SaveKeeper", SaveKeeper)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapGet("GetKeepers", GetKeepers)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task DeleteKeeper(Guid id, IMediator mediator) =>
        mediator.Send(new DeleteKeeperCommand(Id: id), default);

    private Task SaveKeeper(SaveKeeperCommand model, IMediator mediator) =>
        mediator.Send(model, default);

    private Task<List<KeeperSimpleDto>> GetKeepers(IMediator mediator) =>
        mediator.Send(new GetKeepersQuery(), default);
}
