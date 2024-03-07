using MediatR;
using MyBudget.Domain.Enums;
using MyBudget.Application.Interfaces.Dto;

namespace MyBudget.Application.Features.Transaction.Commands.SaveTransaction;

public class SaveTransactionCommand : IRequest
{
    public Guid? Id { get; set; }


    public DateTime Date { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionType Type { get; set; }

    public string? Comment { get; set; }

    public List<TransactionItemSimpleDto> TransactionItems { get; set; } = new();
}
