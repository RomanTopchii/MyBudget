using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.AccountType.AddAccountTypeLink;
using MyBudget.Application.Commands.AccountType.DeleteAccountTypeLink;
using MyBudget.Application.Commands.AccountType.SaveAccountType;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.AccountType.GetAccountTypeById;
using MyBudget.Application.Queries.AccountType.GetAccountTypes;

namespace MyBudget.WebApi.Controllers;

[Route("api/account-types")]
[ApiController]
public class AccountTypeController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccountType(SaveAccountType model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
    
    [HttpPost("add-link")]
    public Task AddAccountTypeLink(AddAccountTypeLink model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
    
    [HttpPost("delete-link")]
    public Task DeleteAccountTypeLink(DeleteAccountTypeLink model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<AccountTypeRichDto>> GetAccountTypes(CancellationToken cancellationToken) =>
        mediator.Send(new GetAccountTypes(), cancellationToken);

    [HttpGet("{id}")]
    public Task<AccountTypeRichDto> GetAccountTypeById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetAccountTypeById(id), cancellationToken);
}