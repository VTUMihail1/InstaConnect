using System.Globalization;

using InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Helpers;
public class EmailConfirmationTokensClient : IEmailConfirmationTokensClient
{
    private readonly HttpClient _httpClient;

    public EmailConfirmationTokensClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAddRoute(request.Email);
        var response = await _httpClient.PostAsync(route, null, cancellationToken);

        return response.StatusCode;
    }

    public async Task AddAsync(
        AddEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAddRoute(request.Email);
        await _httpClient.PostAsync(route, null, cancellationToken);
    }

    public async Task<HttpStatusCode> VerifyStatusCodeAsync(
        VerifyEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetVerifyRoute(request.UserId, request.Token);
        var response = await _httpClient.PutAsync(route, null, cancellationToken);

        return response.StatusCode;
    }

    public async Task VerifyAsync(
        VerifyEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetVerifyRoute(request.UserId, request.Token);
        await _httpClient.PutAsync(route, null, cancellationToken);
    }

    private static string GetAddRoute(string email)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            EmailConfirmationTokenTestRoutes.Add,
            email);

        return route;
    }

    private static string GetVerifyRoute(string userId, string token)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            EmailConfirmationTokenTestRoutes.Verify,
            userId,
            token);

        return route;
    }
}
