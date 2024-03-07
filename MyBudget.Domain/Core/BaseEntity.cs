namespace MyBudget.Domain.Core;

public class BaseEntity
{
    public Guid Id { get; set; }

    public bool Active { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string? ModifiedBy { get; set; }
}
