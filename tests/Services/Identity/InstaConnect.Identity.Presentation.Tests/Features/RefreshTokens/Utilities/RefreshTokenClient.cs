using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> IssueRefreshTokenResponseMessageAsync(
            IssueRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = RefreshTokenTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> IssueRefreshTokenProblemDetailsAsync(
            IssueRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.IssueRefreshTokenResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<IssueRefreshTokenApiResponse> IssueRefreshTokenAsync(
            IssueRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.IssueRefreshTokenResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<IssueRefreshTokenApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> IssueRefreshTokenStatusCodeAsync(
            IssueRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.IssueRefreshTokenResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> RotateRefreshTokenWithoutCookiesResponseMessageAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = RefreshTokenTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsJsonAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> RotateRefreshTokenResponseMessageAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = RefreshTokenTestRoutes.GetRoute(request);

            return await httpClient
                .WithCookies(new(RefreshTokenCookieKeys.Id, request.Id),
                             new(RefreshTokenCookieKeys.Value, request.Value))
                .PostAsJsonAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> RotateRefreshTokenProblemDetailsWithoutCookiesAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.RotateRefreshTokenWithoutCookiesResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> RotateRefreshTokenProblemDetailsAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.RotateRefreshTokenResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<RotateRefreshTokenApiResponse> RotateRefreshTokenAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.RotateRefreshTokenResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<RotateRefreshTokenApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> RotateRefreshTokenStatusCodeWithoutCookiesAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.RotateRefreshTokenWithoutCookiesResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> RotateRefreshTokenStatusCodeAsync(
            RotateRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.RotateRefreshTokenResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeleteCurrentRefreshTokenWithoutCookiesResponseMessageAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = RefreshTokenTestRoutes.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeleteCurrentRefreshTokenResponseMessageAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = RefreshTokenTestRoutes.GetRoute(request);

            return await httpClient
                .WithCookies(new(RefreshTokenCookieKeys.Id, request.Id),
                             new(RefreshTokenCookieKeys.Value, request.Value))
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteCurrentRefreshTokenProblemDetailsWithoutCookiesAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteCurrentRefreshTokenWithoutCookiesResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeleteCurrentRefreshTokenProblemDetailsAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteCurrentRefreshTokenResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeleteCurrentRefreshTokenAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeleteCurrentRefreshTokenResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeleteCurrentRefreshTokenStatusCodeWithoutCookiesAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteCurrentRefreshTokenWithoutCookiesResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeleteCurrentRefreshTokenStatusCodeAsync(
            DeleteCurrentRefreshTokenApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteCurrentRefreshTokenResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
