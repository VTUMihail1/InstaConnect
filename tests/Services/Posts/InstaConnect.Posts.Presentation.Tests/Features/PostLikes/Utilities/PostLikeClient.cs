using System.Net;
using System.Net.Http.Json;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeClient
{
    public static async Task<HttpStatusCode> GetAllPostLikesStatusCodeAsync(
        this HttpClient httpClient,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> GetAllPostLikesProblemDetailsAsync(
        this HttpClient httpClient,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostLikesApiResponse> GetAllPostLikesAsync(
        this HttpClient httpClient,
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostLikesApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostLikesApiResponse> GetAllPostLikesAsync(
        this HttpClient httpClient,
        string id,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetDefault(id);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostLikesApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> GetPostLikeByIdStatusCodeAsync(
        this HttpClient httpClient,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> GetPostLikeByIdProblemDetailsAsync(
        this HttpClient httpClient,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetPostLikeByIdApiResponse> GetPostLikeByIdAsync(
        this HttpClient httpClient,
        GetPostLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
        var response = await httpClient
            .GetFromJsonAsync<GetPostLikeByIdApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> AddPostLikeStatusCodeAsync(
        this HttpClient httpClient,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> AddPostLikeStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .PostStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> AddPostLikeProblemDetailsAsync(
        this HttpClient httpClient,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> AddPostLikeProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .PostProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<AddPostLikeApiResponse> AddPostLikeAsync(
        this HttpClient httpClient,
        AddPostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostAsync<AddPostLikeApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeletePostLikeStatusCodeAsync(
        this HttpClient httpClient,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> DeletePostLikeStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> DeletePostLikeProblemDetailsAsync(
        this HttpClient httpClient,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> DeletePostLikeProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        var response = await httpClient
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task DeletePostLikeAsync(
        this HttpClient httpClient,
        DeletePostLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostLikeTestRoutes.GetCurrent(request.Id);
        await httpClient
            .AddUserId(request.UserId)
            .DeleteAsync(route, cancellationToken);
    }
}
