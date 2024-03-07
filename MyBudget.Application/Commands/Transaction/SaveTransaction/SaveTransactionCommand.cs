using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Transaction.SaveTransaction;

public class SaveTransactionCommand : IRequest
{
    public Guid? Id { get; set; }


    public DateTime Date { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionType Type { get; set; }

    public string? Comment { get; set; }

    public List<TransactionItemSimpleDto> TransactionItems { get; set; } = new();
}
