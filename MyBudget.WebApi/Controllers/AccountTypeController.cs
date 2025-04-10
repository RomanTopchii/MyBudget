using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.AccountType.SaveAccountType;

namespace MyBudget.WebApi.Controllers;

[Route("api/account-types")]
[ApiController]
public class AccountTypeController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccountType(SaveAccountTypeCommand model) 
        => mediator.Send(model, default);
}