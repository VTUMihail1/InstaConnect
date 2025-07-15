using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public static class PostClient
{
    public static async Task<HttpStatusCode> GetAllPostsStatusCodeAsync(
        this HttpClient httpClient,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetAll(request);
        var response = await httpClient.GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> GetAllPostsProblemDetailsAsync(
        this HttpClient httpClient,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetAll(request);
        var response = await httpClient.GetFromJsonAsync<ProblemDetails>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostsApiResponse> GetAllPostsAsync(
        this HttpClient httpClient,
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetAll(request);
        var response = await httpClient.GetFromJsonAsync<GetAllPostsApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetAllPostsApiResponse> GetAllPostsAsync(
        this HttpClient httpClient,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .GetFromJsonAsync<GetAllPostsApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> GetPostByIdStatusCodeAsync(
        this HttpClient httpClient,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient.GetStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> GetPostByIdProblemDetailsAsync(
        this HttpClient httpClient,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient.GetFromJsonAsync<ProblemDetails>(route, cancellationToken);

        return response!;
    }

    public static async Task<GetPostByIdApiResponse> GetPostByIdAsync(
        this HttpClient httpClient,
        GetPostByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient.GetFromJsonAsync<GetPostByIdApiResponse>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> AddPostStatusCodeAsync(
        this HttpClient httpClient,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PostStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<HttpStatusCode> AddPostStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .PostStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> AddPostProblemDetailsAsync(
        this HttpClient httpClient,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PostAsync<AddPostApiBody, ProblemDetails>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> AddPostProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .PostAsync<AddPostApiBody, ProblemDetails>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<AddPostApiResponse> AddPostAsync(
        this HttpClient httpClient,
        AddPostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetDefault();
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PostAsync<AddPostApiBody, AddPostApiResponse>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> UpdatePostStatusCodeAsync(
        this HttpClient httpClient,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PutStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> UpdatePostProblemDetailsAsync(
        this HttpClient httpClient,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PutAsync<UpdatePostApiBody, ProblemDetails>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> UpdatePostProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .PutAsync<UpdatePostApiBody, ProblemDetails>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> UpdatePostStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .PutStatusCodeAsync(route, request.Body, cancellationToken);

        return response;
    }

    public static async Task<UpdatePostApiResponse> UpdatePostAsync(
        this HttpClient httpClient,
        UpdatePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .PutAsync<UpdatePostApiBody, UpdatePostApiResponse>(route, request.Body, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeletePostStatusCodeAsync(
        this HttpClient httpClient,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task<ProblemDetails> DeletePostProblemDetailsAsync(
        this HttpClient httpClient,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .AddUserId(request.CurrentUserId)
            .DeleteFromJsonAsync<ProblemDetails>(route, cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> DeletePostProblemDetailsUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .DeleteFromJsonAsync<ProblemDetails>(route, cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeletePostStatusCodeUnauthorizedAsync(
        this HttpClient httpClient,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        var response = await httpClient
            .DeleteStatusCodeAsync(route, cancellationToken);

        return response;
    }

    public static async Task DeletePostAsync(
        this HttpClient httpClient,
        DeletePostApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = PostTestRoutes.GetId(request.Id);
        await httpClient
            .AddUserId(request.CurrentUserId)
            .DeleteAsync(route, cancellationToken);
    }
}
