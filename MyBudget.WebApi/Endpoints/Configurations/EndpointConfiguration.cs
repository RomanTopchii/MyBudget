namespace MyBudget.WebApi.Endpoints.Configurations;

public abstract class EndpointConfiguration
{
    public const string BaseApiPath = "api/v{version:apiVersion}";
}
