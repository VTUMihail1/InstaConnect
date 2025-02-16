using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Helpers;
public class PostCommentLikesClient : IPostCommentLikesClient
{
    private readonly HttpClient _httpClient;

    public PostCommentLikesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllPostCommentLikesRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentLikePaginationQueryResponse> GetAllAsync(
        GetAllPostCommentLikesRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentLikePaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<PostCommentLikePaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentLikePaginationQueryResponse>(PostCommentLikeTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetPostCommentLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentLikeQueryResponse> GetByIdAsync(
        GetPostCommentLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentLikeQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddPostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(PostCommentLikeTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddPostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(PostCommentLikeTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentLikeCommandResponse> AddAsync(
        AddPostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePostCommentLike = await _httpClient
            .PostAsJsonAsync(PostCommentLikeTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponsePostCommentLike.Content.ReadFromJsonAsync<PostCommentLikeCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeletePostCommentLikeRequest request,
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
        DeletePostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeletePostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllPostCommentLikesRequest request)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            PostCommentLikeTestRoutes.GetAll,
            request.UserId,
            request.UserName,
            request.PostCommentId,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private string IdRoute(string id)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            PostCommentLikeTestRoutes.Id,
            id);

        return route;
    }
}
