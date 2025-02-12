using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Helpers;
public class PostLikesClient : IPostLikesClient
{
    private readonly HttpClient _httpClient;

    public PostLikesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllPostLikesRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostLikePaginationQueryResponse> GetAllAsync(
        GetAllPostLikesRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<PostLikePaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<PostLikePaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<PostLikePaginationQueryResponse>(PostLikeTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetPostLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostLikeQueryResponse> GetByIdAsync(
        GetPostLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<PostLikeQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddPostLikeRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(PostLikeTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddPostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(PostLikeTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostLikeCommandResponse> AddAsync(
        AddPostLikeRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePostLike = await _httpClient
            .PostAsJsonAsync(PostLikeTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponsePostLike.Content.ReadFromJsonAsync<PostLikeCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeletePostLikeRequest request,
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
        DeletePostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeletePostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllPostLikesRequest request)
    {
        var route = string.Format(
            PostLikeTestRoutes.GetAll,
            request.UserId,
            request.UserName,
            request.PostId,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private string IdRoute(string id)
    {
        var route = string.Format(
            PostLikeTestRoutes.Id,
            id);

        return route;
    }
}
