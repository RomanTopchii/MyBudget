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
        mediator.Send(new DeleteCurrencyCommand(Id: id), cancellationToken);
    
    [HttpPost("save")]
    public Task SaveCurrency([FromBody] SaveCurrencyCommand model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpPost("set-accounting")]
    public Task SetAccountingCurrency([FromBody] SetAccountingCurrencyCommand model, CancellationToken cancellationToken) =>
        mediator.Send(model, cancellationToken);
    
    [HttpGet]
    public Task<List<CurrencySimpleDto>> GetCurrencies(CancellationToken cancellationToken) =>
        mediator.Send(new GetCurrenciesQuery(), cancellationToken);

    [HttpGet("{id}")]
    public Task<CurrencySimpleDto> GetCurrencyById([FromRoute] Guid id, CancellationToken cancellationToken) =>
        mediator.Send(new GetCurrencyByIdQuery(id), cancellationToken);
}