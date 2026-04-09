using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Account.ImportAccountsWithRelativeObjects;
using MyBudget.Application.Commands.Account.SaveAccount;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Account.GetAccountById;
using MyBudget.Application.Queries.Account.GetAccountsTree;

namespace MyBudget.WebApi.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccount(SaveAccount model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
    
    [HttpPost("ImportAccountsWithRelativeObjects")]
    public Task SaveAccount(List<ImportAccount> model, CancellationToken cancellationToken) 
        => mediator.Send(new ImportAccountsWithRelativeObjects(List: model), cancellationToken);
    
    [HttpGet]
    public Task<AccountPoorDto?> GetAccountsTree(CancellationToken cancellationToken) =>
        mediator.Send(new GetAccountsTree(), cancellationToken);

    [HttpGet("{id}")]
    public Task<AccountRichDto> GetAccountById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetAccountById(id), cancellationToken);
}