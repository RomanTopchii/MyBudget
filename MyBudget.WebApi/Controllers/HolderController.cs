using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Holder.DeleteHolder;
using MyBudget.Application.Commands.Holder.SaveHolder;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Holder.GetHolderById;
using MyBudget.Application.Queries.Holder.GetHolders;

namespace MyBudget.WebApi.Controllers;

[Route("api/holders")]
[ApiController]
public class HolderController (IMediator mediator): ControllerBase
{
    [HttpDelete]
    public Task DeleteHolder(Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new DeleteHolder(Id: id), cancellationToken);
    
    [HttpPost]
    public Task SaveHolder(SaveHolder model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<HolderSimpleDto>> GetHolders(CancellationToken cancellationToken) =>
        mediator.Send(new GetHolders(), cancellationToken);

    [HttpGet("{id}")]
    public Task<HolderSimpleDto> GetHolderById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetHolderById(id), cancellationToken);
}