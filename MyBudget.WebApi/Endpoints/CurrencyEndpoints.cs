using MediatR;
using Microsoft.OpenApi.Models;
using MyBudget.Application.Commands.Currency.DeleteCurrency;
using MyBudget.Application.Commands.Currency.SaveCurrency;
using MyBudget.Application.Queries.Currency.GetCurrencies;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class CurrencyEndpoints : IApiRoute
{
    private const string Name = "Currency";

    public void Register(WebApplication route)
    {
        var group = route.MapGroup($"api/v1/{Name}")
            .WithOpenApi(operation => new OpenApiOperation(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = Name } }
            });

        group.MapDelete("DeleteCurrency", (Guid id, IMediator mediator) =>
            mediator.Send(new DeleteCurrencyCommand(Id: id), default));

        group.MapPost("SaveCurrency", (SaveCurrencyCommand model, IMediator mediator) =>
            mediator.Send(model, default));

        group.MapGet("GetCurrencies", (IMediator mediator) =>
            mediator.Send(new GetCurrenciesQuery(), default));
    }
}
