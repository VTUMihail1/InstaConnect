using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
public static class PostCommentClient
{
    public static async Task<HttpStatusCode> GetAllPostCommentsStatusCodeAsync(
        this HttpClient httpClient,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetAll(request);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> GetAllPostCommentsProblemDetailsAsync(
        this HttpClient httpClient,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetAll(request);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostCommentsApiResponse> GetAllPostCommentsAsync(
        this HttpClient httpClient,
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetAll(request);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostCommentsApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostCommentsApiResponse> GetAllPostCommentsAsync(
        this HttpClient httpClient,
        string id,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(id);
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostCommentsApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> GetPostCommentByIdStatusCodeAsync(
        this HttpClient httpClient,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> GetPostCommentByIdProblemDetailsAsync(
        this HttpClient httpClient,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .GetProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<GetPostCommentByIdApiResponse> GetPostCommentByIdAsync(
        this HttpClient httpClient,
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .GetFromJsonAsync<GetPostCommentByIdApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> AddPostCommentStatusCodeAsync(
        this HttpClient httpClient,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> AddPostCommentStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(request.Id);
        var response = await httpClient
            .PostStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsAsync(
        this HttpClient httpClient,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostProblemDetailsAsync(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(request.Id);
        var response = await httpClient
            .PostProblemDetailsAsync(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<AddPostCommentApiResponse> AddPostCommentAsync(
        this HttpClient httpClient,
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetDefault(request.Id);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PostAsync<AddPostCommentApiBody, AddPostCommentApiResponse>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> UpdatePostCommentStatusCodeAsync(
        this HttpClient httpClient,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PutStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> UpdatePostCommentStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .PutStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsAsync(
        this HttpClient httpClient,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PutProblemDetailsAsync(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .PutProblemDetailsAsync(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<UpdatePostCommentApiResponse> UpdatePostCommentAsync(
        this HttpClient httpClient,
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .PutAsync<UpdatePostCommentApiBody, UpdatePostCommentApiResponse>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeletePostCommentStatusCodeAsync(
        this HttpClient httpClient,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> DeletePostCommentStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsAsync(
        this HttpClient httpClient,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .AddUserId(request.UserId)
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        var response = await httpClient
            .DeleteProblemDetailsAsync(route, cancellationToken);

        return response!;
    }

    public static async Task DeletePostCommentAsync(
        this HttpClient httpClient,
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
        await httpClient
            .AddUserId(request.UserId)
            .DeleteAsync(route, cancellationToken);
    }
}
