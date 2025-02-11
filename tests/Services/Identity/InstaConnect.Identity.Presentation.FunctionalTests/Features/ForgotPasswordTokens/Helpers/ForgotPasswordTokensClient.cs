using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus.DataSets;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Users.Presentation.FunctionalTests.Features.Users.Helpers;
public class ForgotPasswordTokensClient : IForgotPasswordTokensClient
{
    private readonly HttpClient _httpClient;

    public ForgotPasswordTokensClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddForgotPasswordTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAddRoute(request.Email);
        var response = await _httpClient.PostAsync(route, null, cancellationToken);

        return response.StatusCode;
    }

    public async Task AddAsync(
        AddForgotPasswordTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAddRoute(request.Email);
        await _httpClient.PostAsync(route, null, cancellationToken);
    }

    public async Task<HttpStatusCode> VerifyStatusCodeAsync(
        VerifyForgotPasswordTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetVerifyRoute(request.UserId, request.Token);
        var response = await _httpClient.PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task VerifyAsync(
        VerifyForgotPasswordTokenRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetVerifyRoute(request.UserId, request.Token);
        await _httpClient.PutAsJsonAsync(route, request.Body, cancellationToken);
    }

    private string GetAddRoute(string email)
    {
        var route = string.Format(
            ForgotPasswordTokenTestRoutes.Add,
            email);

        return route;
    }

    private string GetVerifyRoute(string userId, string token)
    {
        var route = string.Format(
            ForgotPasswordTokenTestRoutes.Verify,
            userId,
            token);

        return route;
    }
}
