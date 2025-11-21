using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Account.GetAccountById;

public record GetAccountById(Guid Id) : IRequest<AccountRichDto>;