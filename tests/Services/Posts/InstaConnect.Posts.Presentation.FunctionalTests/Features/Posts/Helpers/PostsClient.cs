using System.Globalization;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Helpers;
public class PostsClient : IPostsClient
{
    private readonly HttpClient _httpClient;

    public PostsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostPaginationQueryResponse> GetAllAsync(
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<PostPaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<PostPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<PostPaginationQueryResponse>(PostTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostQueryResponse> GetByIdAsync(
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<PostQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(PostTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(PostTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommandResponse> AddAsync(
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePost = await _httpClient
            .PostAsJsonAsync(PostTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponsePost.Content.ReadFromJsonAsync<PostCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> UpdateStatusCodeAsync(
        UpdatePostApiRequest request,
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
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<PostCommandResponse> UpdateAsync(
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponsePost = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);
        var response = await httpResponsePost.Content.ReadFromJsonAsync<PostCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeletePostApiRequest request,
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
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private static string GetAllRoute(GetAllPostsApiRequest request)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            PostTestRoutes.GetAll,
            request.UserId,
            request.UserName,
            request.Title,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private static string IdRoute(string id)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            PostTestRoutes.Id,
            id);

        return route;
    }
}
