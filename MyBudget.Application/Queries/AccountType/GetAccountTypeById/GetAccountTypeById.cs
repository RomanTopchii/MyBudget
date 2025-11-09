using MediatR;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Queries.AccountType.GetAccountTypeById;

public record GetAccountTypeById(Guid Id) : IRequest<AccountTypeRichDto>;