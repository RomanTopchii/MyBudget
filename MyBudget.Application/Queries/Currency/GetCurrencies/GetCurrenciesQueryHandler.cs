using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence;

namespace MyBudget.Application.Queries.Currency.GetCurrencies;

public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, List<CurrencySimpleDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCurrenciesQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<List<CurrencySimpleDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        return (await this._unitOfWork.CurrencyRepository.GetAllAsync())
            .Select(x => new CurrencySimpleDto(x))
            .ToList();
    }
}
