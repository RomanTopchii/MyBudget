using MediatR;
using MyBudget.Application.Commands.Transaction.ApplyApprovedTransactions;

namespace MyBudget.WebApi.Jobs;

public record ApplyApprovedTransactionsJob(IMediator Mediator)
{
    public async Task ExecuteAsync()
    {
        await this.Mediator.Send(new ApplyApprovedTransactionsCommand(), default);
    }
}
