using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.AccountType.GetAccountTypes;

public record GetAccountTypesHandler(IAccountTypeRepository AccountTypeRepository)
    : IRequestHandler<GetAccountTypes, List<AccountTypeRichDto>>
{
    public async Task<List<AccountTypeRichDto>> Handle(GetAccountTypes request, CancellationToken cancellationToken)
    {
        return this.AccountTypeRepository.QueryRich()
            .Select(x => new AccountTypeRichDto(x))
            .ToList()
            .OrderBy(x => x.Name)
            .ToList();
    }
}
