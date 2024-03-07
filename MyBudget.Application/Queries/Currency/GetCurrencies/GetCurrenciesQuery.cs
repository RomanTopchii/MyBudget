using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Currency.GetCurrencies;

public class GetCurrenciesQuery : IRequest<List<CurrencySimpleDto>>
{
}
