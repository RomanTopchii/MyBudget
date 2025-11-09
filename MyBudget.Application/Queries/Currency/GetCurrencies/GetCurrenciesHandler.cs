using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Currency.GetCurrencies;

public record GetCurrenciesHandler(ICurrencyRepository CurrencyRepository)
    : IRequestHandler<GetCurrencies, List<CurrencySimpleDto>>
{
    public async Task<List<CurrencySimpleDto>> Handle(GetCurrencies request, CancellationToken cancellationToken)
    {
        return (await this.CurrencyRepository.GetAllAsync())
            .Select(x => new CurrencySimpleDto(x))
            .OrderBy(x => x.Code)
            .ToList();
    }
}
