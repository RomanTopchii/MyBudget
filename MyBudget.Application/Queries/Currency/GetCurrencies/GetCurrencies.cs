using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Currency.GetCurrencies;

public record GetCurrencies : IRequest<List<CurrencySimpleDto>>;
