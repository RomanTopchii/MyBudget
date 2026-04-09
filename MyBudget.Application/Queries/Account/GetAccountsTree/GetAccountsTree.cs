using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.Account.GetAccountsTree;

public record GetAccountsTree : IRequest<AccountPoorDto?>;