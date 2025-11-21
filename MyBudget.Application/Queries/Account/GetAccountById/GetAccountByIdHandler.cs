using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Queries.Account.GetAccountById;

public record GetAccountByIdHandler(IAccountRepository AccountRepository)
    : IRequestHandler<GetAccountById, AccountRichDto>
{
    public async Task<AccountRichDto> Handle(GetAccountById request, CancellationToken cancellationToken)
    {
        var account = await this.AccountRepository.GetRichByIdAsync(request.Id)
                      ?? throw new ObjectNotFoundException<Domain.Account>(request.Id);

        return new AccountRichDto(account);
    }
}