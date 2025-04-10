using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Currency.GetCurrencyById;

public record GetCurrencyByIdQuery(Guid Id) : IRequest<CurrencySimpleDto>;