using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;
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
        GetAllFollowsClientRequest request,
        CancellationToken cancellationToken)
    {
        var getAllFollowsRequest = request.GetAllFollowsRequest;
        var route = GetAllRoute(getAllFollowsRequest);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowPaginationQueryResponse> GetAllAsync(
        GetAllFollowsClientRequest request,
        CancellationToken cancellationToken)
    {
        var getAllFollowsRequest = request.GetAllFollowsRequest;
        var route = GetAllRoute(getAllFollowsRequest);
        var response = await _httpClient
            .GetFromJsonAsync<FollowPaginationQueryResponse>(route, cancellationToken);

        return response!;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetFollowByIdClientRequest request,
        CancellationToken cancellationToken)
    {
        var getFollowByIdRequest = request.GetFollowByIdRequest;
        var route = IdRoute(getFollowByIdRequest.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowQueryResponse> GetByIdAsync(
        GetFollowByIdClientRequest request,
        CancellationToken cancellationToken)
    {
        var getFollowByIdRequest = request.GetFollowByIdRequest;
        var route = IdRoute(getFollowByIdRequest.Id);
        var response = await _httpClient
            .GetFromJsonAsync<FollowQueryResponse>(route, cancellationToken);

        return response!;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddFollowClientRequest request,
        CancellationToken cancellationToken)
    {
        var addFollowRequest = request.AddFollowRequest;

        if (request.IsAuthenticated)
        {
            _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, addFollowRequest.CurrentUserId }
            });
        }

        var response = await _httpClient
            .PostAsJsonAsync(FollowTestRoutes.Default, addFollowRequest, cancellationToken);

        return response.StatusCode;
    }

    public async Task<FollowCommandResponse> AddAsync(
        AddFollowClientRequest request,
        CancellationToken cancellationToken)
    {
        var addFollowRequest = request.AddFollowRequest;
        
        if (request.IsAuthenticated)
        {
            _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, addFollowRequest.CurrentUserId }
            });
        }

        var httpResponseMessage = await _httpClient
            .PostAsJsonAsync(FollowTestRoutes.Default, addFollowRequest, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<FollowCommandResponse>();

        return response!;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeleteFollowClientRequest request,
        CancellationToken cancellationToken)
    {
        var deleteFollowRequest = request.DeleteFollowRequest;
        var route = IdRoute(deleteFollowRequest.Id);

        if (request.IsAuthenticated)
        {
            _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>() 
            { 
                { ClaimTypes.NameIdentifier, deleteFollowRequest.CurrentUserId } 
            });
        }

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeleteFollowClientRequest request,
        CancellationToken cancellationToken)
    {
        var deleteFollowRequest = request.DeleteFollowRequest;
        var route = IdRoute(deleteFollowRequest.Id);

        if (request.IsAuthenticated)
        {
            _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, deleteFollowRequest.Id }
            });
        }

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllFollowsRequest? request)
    {
        if (request == null)
        {
            return FollowTestRoutes.Default;
        }

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
