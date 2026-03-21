using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllPostCommentLikesResponseMessageAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentLikesProblemDetailsAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostCommentLikesApiResponse> GetAllPostCommentLikesAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostCommentLikesApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostCommentLikesStatusCodeAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetAllPostCommentLikesForUserResponseMessageAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentLikesForUserProblemDetailsAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostCommentLikesForUserApiResponse> GetAllPostCommentLikesForUserAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostCommentLikesForUserApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostCommentLikesForUserStatusCodeAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentLikesForUserResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetPostCommentLikeByIdResponseMessageAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetPostCommentLikeByIdProblemDetailsAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentLikeByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetPostCommentLikeByIdApiResponse> GetPostCommentLikeByIdAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentLikeByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetPostCommentLikeByIdApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetPostCommentLikeByIdStatusCodeAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentLikeByIdResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddPostCommentLikeUnauthorizedResponseMessageAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsync(route, null, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddPostCommentLikeResponseMessageAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PostAsync(route, null, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsUnauthorizedAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<AddPostCommentLikeApiResponse> AddPostCommentLikeAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<AddPostCommentLikeApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> AddPostCommentLikeStatusCodeUnauthorizedAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> AddPostCommentLikeStatusCodeAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentLikeResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeletePostCommentLikeUnauthorizedResponseMessageAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeletePostCommentLikeResponseMessageAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsUnauthorizedAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentLikeResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeletePostCommentLikeAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeletePostCommentLikeResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeUnauthorizedAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentLikeUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentLikeResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
