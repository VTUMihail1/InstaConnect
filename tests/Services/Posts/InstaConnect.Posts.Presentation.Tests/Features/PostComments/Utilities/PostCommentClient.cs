using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentClient
{
    extension(HttpClient httpClient)
    {
        public async Task<HttpStatusCode> GetAllPostCommentsStatusCodeAsync(
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentsProblemDetailsAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostCommentsApiResponse> GetAllPostCommentsAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostCommentsApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetAllPostCommentsForUserStatusCodeAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentsForUserProblemDetailsAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostCommentsForUserApiResponse> GetAllPostCommentsForUserAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostCommentsForUserApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetPostCommentByIdStatusCodeAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetPostCommentByIdProblemDetailsAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetPostCommentByIdApiResponse> GetPostCommentByIdAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetPostCommentByIdApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> AddPostCommentStatusCodeAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetDefault(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> AddPostCommentStatusCodeUnauthorizedAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetDefault(request.Id);
            var response = await httpClient
                .PostStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetDefault(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsUnauthorizedAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetDefault(request.Id);
            var response = await httpClient
                .PostProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<AddPostCommentApiResponse> AddPostCommentAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetDefault(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostAsync<AddPostCommentApiBody, AddPostCommentApiResponse>(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> UpdatePostCommentStatusCodeAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> UpdatePostCommentStatusCodeUnauthorizedAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .PutStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsUnauthorizedAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .PutProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<UpdatePostCommentApiResponse> UpdatePostCommentAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutAsync<UpdatePostCommentApiBody, UpdatePostCommentApiResponse>(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> DeletePostCommentStatusCodeAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> DeletePostCommentStatusCodeUnauthorizedAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsUnauthorizedAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            var response = await httpClient
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task DeletePostCommentAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetId(request.Id, request.CommentId);
            await httpClient
                .AddUserId(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }
    }
}
