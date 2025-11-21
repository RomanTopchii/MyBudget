using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class AccountRichDto : DictionaryEntityDto
{
    public AccountSimpleDto? Parent { get; set; }

    public AccountTypeNamedDto Type { get; set; }

    public CurrencySimpleDto? Currency { get; set; }

    public HolderSimpleDto? Holder { get; set; }

    public KeeperSimpleDto? Keeper { get; set; }

    public AccountSimpleDto? LinkedAccount { get; set; }

    public List<AccountSimpleDto> Children { get; set; }

    public AccountRichDto(Domain.Account domain) : base(domain)
    {
        this.Parent = domain.Parent is not null ? new AccountSimpleDto(domain.Parent) : null;
        this.Type = new AccountTypeNamedDto(domain.Type);
        this.Currency = domain.Currency is not null ? new CurrencySimpleDto(domain.Currency) : null;
        this.Holder = domain.Holder is not null ? new HolderSimpleDto(domain.Holder) : null;
        this.Keeper = domain.Keeper is not null ? new KeeperSimpleDto(domain.Keeper) : null;
        this.LinkedAccount = domain.LinkedAccount is not null
            ? new AccountSimpleDto(domain.LinkedAccount)
            : null;
        this.Children = domain.Children.Select(x => new AccountSimpleDto(x)).ToList();
    }
}