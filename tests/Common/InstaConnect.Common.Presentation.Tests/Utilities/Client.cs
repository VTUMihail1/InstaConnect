using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Common.Presentation.Tests.Utilities;

public static class Client
{
    extension(HttpClient httpClient)
    {
        public async Task<HttpStatusCode> GetStatusCodeAsync(string route, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(route, cancellationToken);

            return response.StatusCode;
        }

        public async Task<ApplicationProblemDetails> GetProblemDetailsAsync(string route, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.GetAsync(route, cancellationToken);

            return await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<HttpStatusCode> PostStatusCodeAsync<T>(string route, T request, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsJsonAsync(route, request, cancellationToken);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PostStatusCodeAsync(string route, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsync(route, null, cancellationToken);

            return response.StatusCode;
        }

        public async Task<ApplicationProblemDetails> PostProblemDetailsAsync<T>(string route, T request, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PostAsJsonAsync(route, request, cancellationToken);

            return await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> PostProblemDetailsAsync(string route, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PostAsync(route, null, cancellationToken);

            var s = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine(s);

            return await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<TResult> PostAsync<T, TResult>(string route, T request, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PostAsJsonAsync(route, request, cancellationToken);

            return await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);
        }

        public async Task<TResult> PostAsync<TResult>(string route, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PostAsync(route, null, cancellationToken);

            return await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> PutProblemDetailsAsync<T>(string route, T request, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PutAsJsonAsync(route, request, cancellationToken);

            return await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<HttpStatusCode> PutStatusCodeAsync<T>(string route, T request, CancellationToken cancellationToken)
        {
            var response = await httpClient.PutAsJsonAsync(route, request, cancellationToken);

            return response.StatusCode;
        }

        public async Task<TResult> PutAsync<T, TResult>(string route, T request, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.PutAsJsonAsync(route, request, cancellationToken);

            return await responseMessage.ReadContentFromJsonAsync<TResult>(cancellationToken);
        }

        public async Task<HttpStatusCode> DeleteStatusCodeAsync(string route, CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteAsync(route, cancellationToken);

            return response.StatusCode;
        }

        public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(string route, CancellationToken cancellationToken)
        {
            var responseMessage = await httpClient.DeleteAsync(route, cancellationToken);

            return await responseMessage.ReadProblemDetailsFromJsonAsync(cancellationToken);
        }

        public HttpClient AddUserId(string userId)
        {
            httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, userId }
            });

            return httpClient;
        }

        public HttpClient AddAdmin(string userId)
        {
            httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ApplicationClaims.Admin, ApplicationClaims.Admin }
            });

            return httpClient;
        }
    }

    extension(HttpResponseMessage httpResponseMessage)
    {
        public async Task<T> ReadContentFromJsonAsync<T>(CancellationToken cancellationToken)
        {
            return (await httpResponseMessage.Content.ReadFromJsonAsync<T>(cancellationToken))!;
        }

        public async Task<ApplicationProblemDetails> ReadProblemDetailsFromJsonAsync(CancellationToken cancellationToken)
        {
            return await httpResponseMessage.ReadContentFromJsonAsync<ApplicationProblemDetails>(cancellationToken);
        }
    }
}
