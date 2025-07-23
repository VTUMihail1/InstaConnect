using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Common.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Tests.Utilities;

public static class Client
{
    public static HttpClient AddUserId(this HttpClient httpClient, string userId)
    {
        httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, userId }
        });

        return httpClient;
    }

    public static async Task<HttpStatusCode> GetStatusCodeAsync(this HttpClient httpClient, string route, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public static async Task<ProblemDetails> GetProblemDetailsAsync<T>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.GetAsync(route, cancellationToken);
        var response = await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> PostStatusCodeAsync<T>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsJsonAsync(route, request, cancellationToken);

        return response.StatusCode;
    }

    public static async Task<ProblemDetails> PostProblemDetailsAsync<T>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PostAsJsonAsync(route, request, cancellationToken);
        var response = await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);

        return response!;
    }

    public static async Task<TResult> PostAsync<T, TResult>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PostAsJsonAsync(route, request, cancellationToken);
        var response = await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> PutProblemDetailsAsync<T>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PutAsJsonAsync(route, request, cancellationToken);
        var response = await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> PutStatusCodeAsync<T>(this HttpClient httpClient, string route, T request, CancellationToken cancellationToken)
    {
        var response = await httpClient.PutAsJsonAsync(route, request, cancellationToken);

        return response.StatusCode;
    }

    public static async Task<TResult> PutAsync<T, TResult>(this HttpClient httpClient, string route, T request, CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PutAsJsonAsync(route, request, cancellationToken);
        var response = await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);

        return response!;
    }

    public static async Task<HttpStatusCode> DeleteStatusCodeAsync(this HttpClient httpClient, string route, CancellationToken cancellationToken)
    {
        var response = await httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public static HttpClient AddAdmin(this HttpClient httpClient, string userId)
    {
        httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ApplicationClaims.Admin, ApplicationClaims.Admin }
        });

        return httpClient;
    }

    public static async Task<T> ReadContentFromJsonAsync<T>(
        this HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken)
    {
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<T>(cancellationToken);

        return response!;
    }

    public static async Task<ProblemDetails> ReadProblemDetailsFromJsonAsync(
        this HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken)
    {
        var response = await httpResponseMessage.ReadContentFromJsonAsync<ProblemDetails>(cancellationToken);

        return response!;
    }
}
