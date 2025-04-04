using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Currency.DeleteCurrency;
using MyBudget.Application.Commands.Currency.SaveCurrency;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Currency.GetCurrencies;

namespace MyBudget.WebApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class CurrencyController (IMediator mediator): ControllerBase
{
    [HttpDelete]
    public Task DeleteCurrency(Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new DeleteCurrencyCommand(Id: id), cancellationToken);
    
    [HttpPost]
    public Task SaveCurrency(SaveCurrencyCommand model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<CurrencySimpleDto>> GetCurrencies(CancellationToken cancellationToken) =>
        mediator.Send(new GetCurrenciesQuery(), cancellationToken);
}