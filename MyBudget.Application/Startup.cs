using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyBudget.Application.Validators;

namespace MyBudget.Application;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly);
            
            //cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        
        services
            .AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>))
            .AddValidatorsFromAssembly(typeof(Startup).Assembly);
    }
}
