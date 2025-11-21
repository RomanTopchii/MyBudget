using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Account.GetAccounts;

public record GetAccounts : IRequest<List<AccountRichDto>>;