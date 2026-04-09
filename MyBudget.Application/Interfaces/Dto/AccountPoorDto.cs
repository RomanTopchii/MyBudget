namespace MyBudget.Application.Interfaces.Dto;

public class AccountPoorDto
{
    public Guid Id { get; set; }
    
    public bool Active { get; set; }
    
    public string Name { get; set; }
    
    public Guid? ParentId { get; set; }

    public AccountPoorDto[] Children { get; set; }
    
    public AccountPoorDto(Domain.Account domain)
    {
        this.Id = domain.Id;
        this.Active = domain.Active;
        this.Name = domain.Name;
        this.ParentId = domain.ParentId;
        this.Children = domain.Children.Select(x => new AccountPoorDto(x)).ToArray();
    }
}