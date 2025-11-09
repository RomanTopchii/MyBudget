using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Exceptions.Generic;

namespace MyBudget.Application.Queries.AccountType.GetAccountTypeById;

public record GetAccountTypeByIdHandler(IRepository<Domain.AccountType> AccountTypeRepository)
    : IRequestHandler<GetAccountTypeById, AccountTypeRichDto>
{
    public async Task<AccountTypeRichDto> Handle(GetAccountTypeById request, CancellationToken cancellationToken)
    {
        var currency = await this.AccountTypeRepository.GetByIdAsync(request.Id)
                       ?? throw new ObjectNotFoundException<Domain.AccountType>(request.Id);
        
        return new AccountTypeRichDto(currency);
    }
}
