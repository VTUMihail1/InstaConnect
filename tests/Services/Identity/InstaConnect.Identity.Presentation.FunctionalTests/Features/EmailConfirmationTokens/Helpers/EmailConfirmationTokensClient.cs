using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus.DataSets;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Users.Presentation.FunctionalTests.Features.Users.Helpers;
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

    private string GetAddRoute(string email)
    {
        var route = string.Format(
            EmailConfirmationTokenTestRoutes.Add,
            email);

        return route;
    }

    private string GetVerifyRoute(string userId, string token)
    {
        var route = string.Format(
            EmailConfirmationTokenTestRoutes.Verify,
            userId,
            token);

        return route;
    }
}
