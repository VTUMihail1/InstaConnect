using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeClient
{
    extension(HttpClient httpClient)
    {
        public async Task<HttpStatusCode> GetAllPostLikesStatusCodeAsync(
        GetAllPostLikesApiRequest request,
        CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostLikesProblemDetailsAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostLikesApiResponse> GetAllPostLikesAsync(
            GetAllPostLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostLikesApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetAllPostLikesForUserStatusCodeAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostLikesForUserProblemDetailsAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostLikesForUserApiResponse> GetAllPostLikesForUserAsync(
            GetAllPostLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostLikesForUserApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetPostLikeByIdStatusCodeAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetPostLikeByIdProblemDetailsAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetPostLikeByIdApiResponse> GetPostLikeByIdAsync(
            GetPostLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetId(request.Id, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetPostLikeByIdApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> AddPostLikeStatusCodeAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> AddPostLikeStatusCodeUnauthorizedAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .PostStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> AddPostLikeProblemDetailsAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> AddPostLikeProblemDetailsUnauthorizedAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .PostProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<AddPostLikeApiResponse> AddPostLikeAsync(
            AddPostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostAsync<AddPostLikeApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> DeletePostLikeStatusCodeAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> DeletePostLikeStatusCodeUnauthorizedAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> DeletePostLikeProblemDetailsAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> DeletePostLikeProblemDetailsUnauthorizedAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            var response = await httpClient
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task DeletePostLikeAsync(
            DeletePostLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostLikeTestRoutes.GetCurrent(request.Id);
            await httpClient
                .AddUserId(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }
    }
}
