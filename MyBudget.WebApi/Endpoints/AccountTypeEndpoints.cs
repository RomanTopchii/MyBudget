using MediatR;
using MyBudget.Application.Commands.AccountType.SaveAccountType;
using MyBudget.WebApi.AutoRegistration;

namespace MyBudget.WebApi.Endpoints;

public class AccountTypeEndpoints : IApiRoute
{
    private const string GroupName = "AccountType";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{EndpointConfiguration.BaseApiPath}/{GroupName}");

        group.MapPost("SaveAccountType", SaveAccountType)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private Task SaveAccountType(SaveAccountTypeCommand model, IMediator mediator) =>
        mediator.Send(model, default);
}
