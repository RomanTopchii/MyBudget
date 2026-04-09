using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Application.Queries.Account.GetAccountsTree;

public record GetAccountsTreeHandler(IAccountRepository AccountRepository)
    : IRequestHandler<GetAccountsTree, AccountPoorDto?>
{
    public async Task<AccountPoorDto?> Handle(GetAccountsTree request, CancellationToken cancellationToken)
    {
        var accounts = this.AccountRepository
            .Query(true)
            .Select(x => new AccountPoorDto(x))
            .ToList();
       
        var lookup = accounts.ToLookup(x => x.ParentId);

        var root = accounts.SingleOrDefault(x => x.ParentId == null);
        if (root == null)
            return null;

        FillChildren(root);
        
        return root;

        void FillChildren(AccountPoorDto account)
        {
            var children = lookup[account.Id].ToArray();
            account.Children = children;

            foreach (var child in children)
            {
                FillChildren(child);
            }
        }
    }
}