using Microsoft.AspNetCore.WebUtilities;
using MyBudget.WebApi.Helpers;

namespace MyBudget.WebApi.GoogleAuth;

public class GoogleOAuthService
{
    public const string ClientId = "";
    public const string ClientSecret = "";

    public static string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChallenge)
    {
        var oAuthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        var queryParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "redirect_uri", redirectUrl },
            { "response_type", "code" },
            { "scope", scope },
            { "code_challenge", codeChallenge },
            { "code_challenge_method", "S256" },
            { "access_type", "offline"}
        };
        var url = QueryHelpers.AddQueryString(oAuthServerEndpoint, queryParams);
        return url;
    }

    public static async Task<TokenResult> ExchangeCodeOnToken(string code, string codeVerifier, string redirectUri)
    {
        var tokenEndpoint = "https://oauth2.googleapis.com/token";
        var authParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "code", code },
            { "code_verifier", codeVerifier},
            { "grant_type", "authorization_code" },
            { "redirect_uri", redirectUri }
        };

       var tokenResult =  await HttpClientHelper.SendPostRequest<TokenResult>(tokenEndpoint, authParams);
       return tokenResult;
    }

    public static object RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }
}
