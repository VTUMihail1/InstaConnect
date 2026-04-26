using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllUserClaimsUnauthorizedResponseMessageAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .GetAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> GetAllUserClaimsForbiddenResponseMessageAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentId)
                .GetAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> GetAllUserClaimsResponseMessageAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAdminAuthorization(request.CurrentId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllUserClaimsProblemDetailsUnauthorizedAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllUserClaimsProblemDetailsForbiddenAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsForbiddenResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
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

        public async Task<HttpStatusCode> GetAllUserClaimsStatusCodeUnauthorizedAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> GetAllUserClaimsStatusCodeForbiddenAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsForbiddenResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> GetAllUserClaimsStatusCodeAsync(
            GetAllUserClaimsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllUserClaimsResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddUserClaimUnauthorizedResponseMessageAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddUserClaimForbiddenResponseMessageAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.Id)
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddUserClaimResponseMessageAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAdminAuthorization(request.Id)
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddUserClaimProblemDetailsUnauthorizedAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddUserClaimProblemDetailsForbiddenAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimForbiddenResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
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

        public async Task<HttpStatusCode> AddUserClaimStatusCodeUnauthorizedAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> AddUserClaimStatusCodeForbiddenAsync(
            AddUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddUserClaimForbiddenResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
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
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeleteUserClaimForbiddenResponseMessageAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.Id)
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeleteUserClaimResponseMessageAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = UserClaimRouteFactory.GetRoute(request);

            return await httpClient
                .WithAdminAuthorization(request.Id)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteUserClaimProblemDetailsUnauthorizedAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteUserClaimProblemDetailsForbiddenAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimForbiddenResponseMessageAsync(request, cancellationToken);

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

        public async Task<HttpStatusCode> DeleteUserClaimStatusCodeForbiddenAsync(
            DeleteUserClaimApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteUserClaimForbiddenResponseMessageAsync(request, cancellationToken);

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
