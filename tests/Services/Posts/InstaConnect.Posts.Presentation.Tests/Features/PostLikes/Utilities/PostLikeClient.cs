using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllPostLikesResponseMessageAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostLikesProblemDetailsAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostLikesApiResponse> GetAllPostLikesAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostLikesApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostLikesStatusCodeAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetAllPostLikesForUserResponseMessageAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostLikesForUserProblemDetailsAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostLikesForUserApiResponse> GetAllPostLikesForUserAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostLikesForUserApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostLikesForUserStatusCodeAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostLikesForUserResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetPostLikeByIdResponseMessageAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetPostLikeByIdProblemDetailsAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostLikeByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetPostLikeByIdApiResponse> GetPostLikeByIdAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostLikeByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetPostLikeByIdApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetPostLikeByIdStatusCodeAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostLikeByIdResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddPostLikeUnauthorizedResponseMessageAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithoutAuthorization()
                .PostAsync(route, null, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddPostLikeResponseMessageAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PostAsync(route, null, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostLikeProblemDetailsUnauthorizedAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostLikeProblemDetailsAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<AddPostLikeApiResponse> AddPostLikeAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<AddPostLikeApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> AddPostLikeStatusCodeUnauthorizedAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> AddPostLikeStatusCodeAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostLikeResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeletePostLikeUnauthorizedResponseMessageAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithoutAuthorization()
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeletePostLikeResponseMessageAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostLikeProblemDetailsUnauthorizedAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostLikeProblemDetailsAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeletePostLikeAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeletePostLikeResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeletePostLikeStatusCodeUnauthorizedAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeletePostLikeStatusCodeAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostLikeResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
