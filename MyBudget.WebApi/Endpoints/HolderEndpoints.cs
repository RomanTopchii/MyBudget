using MediatR;
using MyBudget.Application.Commands.Holder.DeleteHolder;
using MyBudget.Application.Commands.Holder.SaveHolder;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Holder.GetHolders;
using MyBudget.WebApi.AutoRegistration;
using MyBudget.WebApi.Endpoints.Configurations;

namespace MyBudget.WebApi.Endpoints;

public class HolderEndpoints : IApiRoute
{
    private const string GroupName = "Holder";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapDelete("DeleteHolder", DeleteHolder)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapPost("SaveHolder", SaveHolder)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapGet("GetHolders", GetHolders)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task DeleteHolder(Guid id, IMediator mediator) =>
        mediator.Send(new DeleteHolderCommand(Id: id), default);

    private Task SaveHolder(SaveHolderCommand model, IMediator mediator) =>
        mediator.Send(model, default);

    private Task<List<HolderSimpleDto>> GetHolders(IMediator mediator) =>
        mediator.Send(new GetHoldersQuery(), default);
}
