using MediatR;
using MyBudget.Application.Commands.Currency.DeleteCurrency;
using MyBudget.Application.Commands.Currency.SaveCurrency;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Queries.Currency.GetCurrencies;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class CurrencyEndpoints : IApiRoute
{
    private const string GroupName = "Currency";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapDelete("DeleteCurrency", DeleteCurrency)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapPost("SaveCurrency", SaveCurrency)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapGet("GetCurrencies", GetCurrencies)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task DeleteCurrency(Guid id, IMediator mediator) =>
        mediator.Send(new DeleteCurrencyCommand(Id: id), default);

    private Task SaveCurrency(SaveCurrencyCommand model, IMediator mediator) =>
        mediator.Send(model, default);

    private Task<List<CurrencySimpleDto>> GetCurrencies(IMediator mediator) =>
        mediator.Send(new GetCurrenciesQuery(), default);
}
