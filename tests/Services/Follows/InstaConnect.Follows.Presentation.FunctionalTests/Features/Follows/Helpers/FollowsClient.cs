using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Helpers;
public class FollowsClient : IFollowsClient
{
    private readonly HttpClient _httpClient;

    public FollowsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllFollowsRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(FollowTestRoutes.Default, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowPaginationQueryResponse> GetAllAsync(
        GetAllFollowsRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<FollowPaginationQueryResponse>(route, cancellationToken);

        return response!;
    }

    public async Task<FollowPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<FollowPaginationQueryResponse>(FollowTestRoutes.Default, cancellationToken);

        return response!;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetFollowByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowQueryResponse> GetByIdAsync(
        GetFollowByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<FollowQueryResponse>(route, cancellationToken);

        return response!;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddFollowRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(FollowTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddFollowRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FollowTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowCommandResponse> AddAsync(
        AddFollowRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponseMessage = await _httpClient
            .PostAsJsonAsync(FollowTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<FollowCommandResponse>(cancellationToken);

        return response!;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeleteFollowRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(
        DeleteFollowRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeleteFollowRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllFollowsRequest request)
    {
        var route = string.Format(
            FollowTestRoutes.GetAll,
            request.FollowerId,
            request.FollowerName,
            request.FollowingId,
            request.FollowingName,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private string IdRoute(string id)
    {
        var route = string.Format(
            FollowTestRoutes.Id,
            id);

        return route;
    }
}
