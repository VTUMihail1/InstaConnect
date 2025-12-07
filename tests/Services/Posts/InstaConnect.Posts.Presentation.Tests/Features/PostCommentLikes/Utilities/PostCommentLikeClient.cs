using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeClient
{
    public static async Task<HttpStatusCode> GetAllPostCommentLikesStatusCodeAsync(
        this HttpClient httpClient,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> GetAllPostCommentLikesProblemDetailsAsync(
        this HttpClient httpClient,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostCommentLikesApiResponse> GetAllPostCommentLikesAsync(
        this HttpClient httpClient,
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetAll(request);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostCommentLikesApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostCommentLikesApiResponse> GetAllPostCommentLikesAsync(
        this HttpClient httpClient,
        string id,
        string commentId,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetDefault(id, commentId);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostCommentLikesApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> GetPostCommentLikeByIdStatusCodeAsync(
        this HttpClient httpClient,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> GetPostCommentLikeByIdProblemDetailsAsync(
        this HttpClient httpClient,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetPostCommentLikeByIdApiResponse> GetPostCommentLikeByIdAsync(
        this HttpClient httpClient,
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
        var response = await httpClient
            .GetFromJsonAsync<GetPostCommentLikeByIdApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> AddPostCommentLikeStatusCodeAsync(
        this HttpClient httpClient,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> AddPostCommentLikeStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .PostStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsAsync(
        this HttpClient httpClient,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .PostProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<AddPostCommentLikeApiResponse> AddPostCommentLikeAsync(
        this HttpClient httpClient,
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostAsync<AddPostCommentLikeApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeAsync(
        this HttpClient httpClient,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsAsync(
        this HttpClient httpClient,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        var response = await httpClient
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task DeletePostCommentLikeAsync(
        this HttpClient httpClient,
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
        await httpClient
            .AddUserId(request.UserId)
            .DeleteAsync(route, cancellationToken);
    }
}
