using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Application.Commands.Currency.DeleteCurrency;
using MyBudget.Application.Commands.Currency.SaveCurrency;
using MyBudget.Application.Commands.Currency.SetAccountingCurrency;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Currency.GetCurrencies;
using MyBudget.Application.Queries.Currency.GetCurrencyById;

namespace MyBudget.WebApi.Controllers;

[Route("api/currencies")]
[ApiController]
public class CurrencyController (IMediator mediator): ControllerBase
{
    [HttpDelete]
    public Task DeleteCurrency([FromQuery] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new DeleteCurrency(Id: id), cancellationToken);
    
    [HttpPost("save")]
    public Task SaveCurrency([FromBody] SaveCurrency model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpPost("set-accounting")]
    public Task SetAccountingCurrency([FromBody] SetAccountingCurrency model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<CurrencySimpleDto>> GetCurrencies(CancellationToken cancellationToken) =>
        mediator.Send(new GetCurrencies(), cancellationToken);

    [HttpGet("{id}")]
    public Task<CurrencySimpleDto> GetCurrencyById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetCurrencyById(id), cancellationToken);
}