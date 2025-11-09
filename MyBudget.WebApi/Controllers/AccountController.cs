using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Account.SaveAccount;

namespace MyBudget.WebApi.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccount(SaveAccount model, CancellationToken cancellationToken) 
        => mediator.Send(model, cancellationToken);
}