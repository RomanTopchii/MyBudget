using Microsoft.AspNetCore.Mvc;
using MyBudget.WebApi.AutoRegistration;
using MyBudget.WebApi.GoogleAuth;
using MyBudget.WebApi.Helpers;

namespace MyBudget.WebApi.Endpoints;

public class GoogleOAuthEndpoints : IApiRoute
{
    private const string GroupName = "GoogleOAuth";

    public void Register(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup($"{GroupName}");

        group.MapGet("RedirectOnOAuthServer", RedirectOnOAuthServer)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);

        group.MapGet("Code", Code)
            .WithApiVersionSet(builder.NewApiVersionSet(GroupName).Build())
            .HasApiVersion(1.0);
    }

    private ActionResult RedirectOnOAuthServer([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var scope = "https://www.googleapis.com/auth/userinfo.email";
        var redirectUrl = $"http://localhost:5191/GoogleOAuth/Code";

        var codeVerifier = Guid.NewGuid().ToString();
        httpContextAccessor.HttpContext?.Session.SetString("codeVerifier", codeVerifier);
        var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);

        var url = GoogleOAuthService.GenerateOAuthRequestUrl(scope, redirectUrl, codeChallenge);
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException("ArgumentCannotBeNullOrEmpty", nameof(url));
        }

        return new RedirectResult(url);
    }

    private async Task<ActionResult> Code([FromServices] IHttpContextAccessor httpContextAccessor, string code)
    {
        var codeVerifier = httpContextAccessor.HttpContext?.Session.GetString("codeVerifier");
        var redirectUrl = $"http://localhost:5191/GoogleOAuth/Code";
        var tokenResult = await GoogleOAuthService.ExchangeCodeOnToken(code, codeVerifier, redirectUrl);

        return new OkResult();
    }
}
