using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Common.Presentation.Tests.Utilities;

public static class Client
{
    extension(HttpClient httpClient)
    {
        public HttpClient WithoutAuthorization()
        {
            httpClient.SetFakeJwtBearerToken([]);

            return httpClient;
        }
        public HttpClient WithAuthorization(string userId)
        {
            httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { DefaultClaims.Id, userId }
            });

            return httpClient;
        }

        public HttpClient WithAdminAuthorization(string userId)
        {
            httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { DefaultClaims.Id, userId },
                { ApplicationClaims.Admin.GetName(), ApplicationClaims.Admin.GetName() }
            });

            return httpClient;
        }

        public HttpClient WithCookies(params Cookie[] cookies)
        {
            const string CookieHeader = "Cookie";
            const string Format = "{0}={1}";

            var cookieHeader = cookies.Select(cookie => Format.FormatCurrentCulture(cookie.Name, cookie.Value)).JoinAsStringWithSemicolon();

            httpClient.DefaultRequestHeaders.Remove(CookieHeader);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CookieHeader, cookieHeader);

            return httpClient;
        }
    }

    extension(HttpResponseMessage httpResponseMessage)
    {
        public async Task<T> GetFromJsonAsync<T>(CancellationToken cancellationToken)
        {
            return (await httpResponseMessage.Content.ReadFromJsonAsync<T>(cancellationToken))!;
        }

        public async Task<ApplicationProblemDetails> GetProblemDetailsFromJsonAsync(CancellationToken cancellationToken)
        {
            return await httpResponseMessage.GetFromJsonAsync<ApplicationProblemDetails>(cancellationToken);
        }

        public HttpStatusCode GetStatusCode()
        {
            return httpResponseMessage.StatusCode;
        }
    }
}
