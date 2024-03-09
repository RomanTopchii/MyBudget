using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Currency.GetCurrencies;

public record GetCurrenciesQueryHandler(ICurrencyRepository CurrencyRepository)
    : IRequestHandler<GetCurrenciesQuery, List<CurrencySimpleDto>>
{
    public async Task<List<CurrencySimpleDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        return (await this.CurrencyRepository.GetAllAsync())
            .Select(x => new CurrencySimpleDto(x))
            .ToList();
    }
}
