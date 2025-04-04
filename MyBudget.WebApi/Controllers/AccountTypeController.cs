using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.AccountType.SaveAccountType;

namespace MyBudget.WebApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AccountTypeController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task SaveAccountType(SaveAccountTypeCommand model) 
        => mediator.Send(model, default);
}