using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Keeper.DeleteKeeper;
using MyBudget.Application.Commands.Keeper.SaveKeeper;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Keeper.GetKeeperById;
using MyBudget.Application.Queries.Keeper.GetKeepers;

namespace MyBudget.WebApi.Controllers;

[Route("api/keepers")]
[ApiController]
public class KeeperController(IMediator mediator) : ControllerBase
{
    [HttpDelete]
    public Task DeleteKeeper(Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new DeleteKeeperCommand(Id: id), cancellationToken);

    [HttpPost]
    public Task SaveKeeper(SaveKeeperCommand model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);

    [HttpGet]
    public Task<List<KeeperSimpleDto>> GetKeepers(CancellationToken cancellationToken) =>
        mediator.Send(new GetKeepersQuery(), cancellationToken);

    [HttpGet("{id}")]
    public Task<KeeperSimpleDto> GetKeeperById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetKeeperByIdQuery(id), cancellationToken);
}