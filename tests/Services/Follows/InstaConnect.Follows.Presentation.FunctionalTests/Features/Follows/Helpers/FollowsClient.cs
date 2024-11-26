using System.Net;
using System.Net.Http.Json;
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

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllFollowsRequest? request = null)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route);

        return response.StatusCode;
    }

    public async Task<FollowPaginationQueryResponse> GetAllAsync(GetAllFollowsRequest? request = null)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetFromJsonAsync<FollowPaginationQueryResponse>(route);

        return response!;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(GetFollowByIdRequest request)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route);

        return response.StatusCode;
    }

    public async Task<FollowQueryResponse> GetByIdAsync(GetFollowByIdRequest request)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetFromJsonAsync<FollowQueryResponse>(route);

        return response!;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(AddFollowRequest request, Dictionary<string, object>? jwtConfig = null)
    {
        if (jwtConfig != null)
        {
            _httpClient.SetFakeJwtBearerToken(jwtConfig);
        }

        var response = await _httpClient.PostAsJsonAsync(FollowTestRoutes.Default, request.AddFollowBindingModel);

        var c = await response.Content.ReadAsStringAsync();

        return response.StatusCode;
    }

    public async Task<FollowCommandResponse> AddAsync(AddFollowRequest request, Dictionary<string, object>? jwtConfig = null)
    {
        if (jwtConfig != null)
        {
            _httpClient.SetFakeJwtBearerToken(jwtConfig);
        }

        var httpResponseMessage = await _httpClient.PostAsJsonAsync(FollowTestRoutes.Default, request.AddFollowBindingModel);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<FollowCommandResponse>();

        return response!;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteFollowRequest request, Dictionary<string, object>? jwtConfig = null)
    {
        var route = IdRoute(request.Id);

        if (jwtConfig != null)
        {
            _httpClient.SetFakeJwtBearerToken(jwtConfig);
        }

        var response = await _httpClient.DeleteAsync(route);

        return response.StatusCode;
    }

    public async Task DeleteAsync(DeleteFollowRequest request, Dictionary<string, object>? jwtConfig = null)
    {
        var route = IdRoute(request.Id);

        if (jwtConfig != null)
        {
            _httpClient.SetFakeJwtBearerToken(jwtConfig);
        }

        await _httpClient.DeleteAsync(route);
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
