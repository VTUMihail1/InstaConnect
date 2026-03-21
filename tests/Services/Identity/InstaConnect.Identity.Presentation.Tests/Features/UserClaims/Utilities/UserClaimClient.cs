using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllUserClaimsResponseMessageAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllUserClaimsProblemDetailsAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllUserClaimsApiResponse> GetAllUserClaimsAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllUserClaimsApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllUserClaimsStatusCodeAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddUserClaimResponseMessageAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsync(route, null, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddUserClaimProblemDetailsAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<AddUserClaimApiResponse> AddUserClaimAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<AddUserClaimApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> AddUserClaimStatusCodeAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeleteUserClaimUnauthorizedResponseMessageAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimTestRoutes.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeleteUserClaimResponseMessageAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.Id)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteUserClaimProblemDetailsUnauthorizedAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteUserClaimProblemDetailsAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeleteUserClaimAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeleteUserClaimResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeleteUserClaimStatusCodeUnauthorizedAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeleteUserClaimStatusCodeAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
