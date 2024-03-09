using MediatR;
using MyBudget.Application.Interfaces.Dto;
using MyBudget.Domain.Enums;

namespace MyBudget.Application.Commands.Transaction.SaveTransaction;

public record SaveTransactionCommand(Guid? Id,
    DateTime Date,
    TransactionStatus Status,
    TransactionType Type,
    string? Comment,
    List<TransactionItemSimpleDto> TransactionItems
) : IRequest;
