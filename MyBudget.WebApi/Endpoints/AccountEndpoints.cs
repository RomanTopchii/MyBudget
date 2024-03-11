using MediatR;
using MyBudget.Application.Commands.Account.SaveAccount;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class AccountEndpoints : IApiRoute
{
    private const string GroupName = "Account";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapPost("SaveAccount", SaveAccount)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task SaveAccount(SaveAccountCommand model, IMediator mediator) =>
        mediator.Send(model, default);
}
