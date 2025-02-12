using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Helpers;
public class PostCommentsClient : IPostCommentsClient
{
    private readonly HttpClient _httpClient;

    public PostCommentsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllPostCommentsRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentPaginationQueryResponse> GetAllAsync(
        GetAllPostCommentsRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentPaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<PostCommentPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentPaginationQueryResponse>(PostCommentTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetPostCommentByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentQueryResponse> GetByIdAsync(
        GetPostCommentByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<PostCommentQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddPostCommentRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(PostCommentTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddPostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(PostCommentTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentCommandResponse> AddAsync(
        AddPostCommentRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePostComment = await _httpClient
            .PostAsJsonAsync(PostCommentTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponsePostComment.Content.ReadFromJsonAsync<PostCommentCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> UpdateStatusCodeAsync(
        UpdatePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(
        UpdatePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommentCommandResponse> UpdateAsync(
        UpdatePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePostComment = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);
        var response = await httpResponsePostComment.Content.ReadFromJsonAsync<PostCommentCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeletePostCommentRequest request,
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
        DeletePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeletePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllPostCommentsRequest request)
    {
        var route = string.Format(
            PostCommentTestRoutes.GetAll,
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
            PostCommentTestRoutes.Id,
            id);

        return route;
    }
}
