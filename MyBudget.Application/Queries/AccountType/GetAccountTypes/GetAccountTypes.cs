using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.AccountType.GetAccountTypes;

public record GetAccountTypes : IRequest<List<AccountTypeRichDto>>;