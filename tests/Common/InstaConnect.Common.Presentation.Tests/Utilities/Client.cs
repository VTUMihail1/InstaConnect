using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Common.Presentation.Tests.Utilities;

public static class Client
{
    public static async Task<HttpStatusCode> GetStatusCodeAsync(this HttpClient httpClient, string route, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public static async Task<ApplicationProblemDetails> GetProblemDetailsAsync(
        this HttpClient httpClient,
        string route,
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

    public static async Task<HttpStatusCode> PostStatusCodeAsync(
        this HttpClient httpClient,
        string route,
        CancellationToken cancellationToken)
    {
        var response = await httpClient.PostAsync(route, null, cancellationToken);

        return response.StatusCode;
    }

    public static async Task<ApplicationProblemDetails> PostProblemDetailsAsync<T>(
        this HttpClient httpClient,
        string route,
        T request,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PostAsJsonAsync(route, request, cancellationToken);
        var response = await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> PostProblemDetailsAsync(
        this HttpClient httpClient,
        string route,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PostAsync(route, null, cancellationToken);

        var s = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

        Console.WriteLine(s);

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

    public static async Task<TResult> PostAsync<TResult>(
        this HttpClient httpClient,
        string route,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.PostAsync(route, null, cancellationToken);
        var response = await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);

        return response!;
    }

    public static async Task<ApplicationProblemDetails> PutProblemDetailsAsync<T>(
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

    public static async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
        this HttpClient httpClient,
        string route,
        CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.DeleteAsync(route, cancellationToken);
        var response = await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);

        return response!;
    }

    public static HttpClient AddUserId(this HttpClient httpClient, string userId)
    {
        httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, userId }
        });

        return httpClient;
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

    public static async Task<ApplicationProblemDetails> ReadProblemDetailsFromJsonAsync(
        this HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken)
    {
        var response = await httpResponseMessage.ReadContentFromJsonAsync<ApplicationProblemDetails>(cancellationToken);

        return response!;
    }
}
