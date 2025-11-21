using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Account.SaveAccount;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Account.GetAccountById;
using MyBudget.Application.Queries.Account.GetAccounts;

namespace MyBudget.WebApi.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccount(SaveAccount model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<AccountRichDto>> GetAccounts(CancellationToken cancellationToken) =>
        mediator.Send(new GetAccounts(), cancellationToken);

    [HttpGet("{id}")]
    public Task<AccountRichDto> GetAccountById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetAccountById(id), cancellationToken);
}