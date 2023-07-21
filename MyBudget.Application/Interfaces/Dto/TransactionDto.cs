using MyBudget.Application.Interfaces.Dto.Core;

namespace MyBudget.Application.Interfaces.Dto;

public class TransactionDto : IdentifiableDto
{
    public DateTime Date { get; set; }

    public string? Comment { get; set; }

    public List<TransactionItemDto> Items { get; set; }

    public TransactionDto(Domain.Transaction domain) : base(domain)
    {
        this.Date = domain.Date;
        this.Comment = domain.Comment;
        this.Items = domain.TransactionItems.Select(x => new TransactionItemDto(x)).ToList();
    }
}