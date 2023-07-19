using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Features.Currency.Queries.GetCurrencies;

public class GetCurrenciesQuery : IRequest<List<CurrencySimpleDto>>
{
}
