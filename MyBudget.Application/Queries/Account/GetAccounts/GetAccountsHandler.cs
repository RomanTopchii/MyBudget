using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Account.GetAccounts;

public record GetAccountsHandler(IAccountRepository AccountRepository)
    : IRequestHandler<GetAccounts, List<AccountRichDto>>
{
    public async Task<List<AccountRichDto>> Handle(GetAccounts request, CancellationToken cancellationToken)
    {
        return this.AccountRepository.QueryRich()
            .Select(x => new AccountRichDto(x))
            .ToList();
    }
}