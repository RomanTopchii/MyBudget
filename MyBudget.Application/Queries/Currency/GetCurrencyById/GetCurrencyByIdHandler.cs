using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Queries.Currency.GetCurrencyById;

public record GetCurrencyByIdHandler(ICurrencyRepository CurrencyRepository)
    : IRequestHandler<GetCurrencyById, CurrencySimpleDto>
{
    public async Task<CurrencySimpleDto> Handle(GetCurrencyById request, CancellationToken cancellationToken)
    {
        var currency = await this.CurrencyRepository.GetByIdAsync(request.Id)
                       ?? throw new ObjectNotFoundException<Domain.Currency>(request.Id);
        
        return new CurrencySimpleDto(currency);
    }
}
