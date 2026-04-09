using MediatR;
using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Account.ImportAccountsWithRelativeObjects;

public record ImportAccountsWithRelativeObjectsHandler(
    IAccountRepository AccountRepository,
    IRepository<Domain.AccountType> AccountTypeRepository,
    ICurrencyRepository CurrencyRepository,
    IHolderRepository HolderRepository,
    IKeeperRepository KeeperRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<ImportAccountsWithRelativeObjects>
{
    public async Task Handle(ImportAccountsWithRelativeObjects request, CancellationToken cancellationToken)
    {
        var currenciesToRemove = this.CurrencyRepository.Query().ToList();
        this.CurrencyRepository.RemoveRange(currenciesToRemove);
        
        var currencies = request.List
            .Select(x => x.Currency)
            .Where(x => x != null)
            .DistinctBy(x => x.Id)
            .Select(x => new Domain.Currency { 
                Id = x.Id, 
                Code = x.Code, 
                Iso4217 = x.Iso4217,
                IsAccounting = x.IsAccounting,
                Active = true
            })
            .ToList(); 
        await this.CurrencyRepository.AddRangeAsync(currencies);
        
        var keepers = request.List
            .Select(x => x.Keeper)
            .Where(x => x != null)
            .DistinctBy(x => x.Id)
            .Select(x => new Domain.Keeper() { 
                Id = x.Id, 
                Name = x.Name, 
                Type = (KeeperType)x.Type,
                Active = true
            })
            .ToList();
        await this.KeeperRepository.AddRangeAsync(keepers);
        
        var holders = request.List
            .Select(x => x.Holder)
            .Where(x => x != null)
            .DistinctBy(x => x.Id)
            .Select(x => new Domain.Holder() { 
                Id = x.Id, 
                Name = x.Name,
                Active = true
            })
            .ToList();
        await this.HolderRepository.AddRangeAsync(holders);

        var accountTypes = this.AccountTypeRepository.Query().ToList();

        var accounts = request.List
            .Select(x => new Domain.Account { Id = x.Id })
            .ToList();

        foreach (var importAccount in request.List)
        {
            var account = accounts.First(x => x.Id == importAccount.Id);
            account.Active = importAccount.Active;
            account.Name = importAccount.Name;
            account.Parent = accounts.FirstOrDefault(x => x.Id == importAccount.ParentId);
            account.Type = accountTypes.First(x => x.Name == importAccount.Type);
            if (importAccount.Currency is not null)
            {
                account.Currency = currencies.FirstOrDefault(x => x.Code == importAccount.Currency?.Code);
            }

            if (importAccount.Holder is not null)
            {
                account.Holder = holders.FirstOrDefault(x => x.Id == importAccount.Holder?.Id);
            }

            if (importAccount.Keeper is not null)
            {
                account.Keeper = keepers.FirstOrDefault(x => x.Id == importAccount.Keeper?.Id);
            }
        }
        await this.AccountRepository.AddRangeAsync(accounts);
        
        this.UnitOfWork.Complete();
        
        foreach (var importAccount in request.List.Where(x=> x.LinkedAccountId is not null))
        {
            var account = accounts.First(x => x.Id == importAccount.Id); 
            account.LinkedAccount = accounts.FirstOrDefault(x => x.Id == importAccount.LinkedAccountId);
        }
        
        this.UnitOfWork.Complete();
    }
}