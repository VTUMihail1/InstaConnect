using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeClient
{
    extension(HttpClient httpClient)
    {
        public async Task<HttpStatusCode> GetAllPostCommentLikesStatusCodeAsync(
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentLikesProblemDetailsAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostCommentLikesApiResponse> GetAllPostCommentLikesAsync(
            GetAllPostCommentLikesApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostCommentLikesApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetAllPostCommentLikesForUserStatusCodeAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentLikesForUserProblemDetailsAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostCommentLikesForUserApiResponse> GetAllPostCommentLikesForUserAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostCommentLikesForUserApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetPostCommentLikeByIdStatusCodeAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetPostCommentLikeByIdProblemDetailsAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetPostCommentLikeByIdApiResponse> GetPostCommentLikeByIdAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetId(request.Id, request.CommentId, request.UserId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetPostCommentLikeByIdApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> AddPostCommentLikeStatusCodeAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> AddPostCommentLikeStatusCodeUnauthorizedAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .PostStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> AddPostCommentLikeProblemDetailsUnauthorizedAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .PostProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<AddPostCommentLikeApiResponse> AddPostCommentLikeAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostAsync<AddPostCommentLikeApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> DeletePostCommentLikeStatusCodeUnauthorizedAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentLikeProblemDetailsUnauthorizedAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            var response = await httpClient
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task DeletePostCommentLikeAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentLikeTestRoutes.GetCurrent(request.Id, request.CommentId);
            await httpClient
                .AddUserId(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }
    }
}
