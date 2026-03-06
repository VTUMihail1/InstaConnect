using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Bodies;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostClient
{
    extension(HttpClient httpClient)
    {
        public async Task<HttpStatusCode> GetAllPostsStatusCodeAsync(
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostsProblemDetailsAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostsApiResponse> GetAllPostsAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAll(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostsApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetAllPostsForUserStatusCodeAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetAllPostsForUserProblemDetailsAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetAllPostsForUserApiResponse> GetAllPostsForUserAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetAllForUser(request);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetAllPostsForUserApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> GetPostByIdStatusCodeAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> GetPostByIdProblemDetailsAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<GetPostByIdApiResponse> GetPostByIdAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.CurrentUserId)
                .GetFromJsonAsync<GetPostByIdApiResponse>(route, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> AddPostStatusCodeAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetDefault();
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> AddPostStatusCodeUnauthorizedAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetDefault();
            var response = await httpClient
                .PostStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> AddPostProblemDetailsAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetDefault();
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> AddPostProblemDetailsUnauthorizedAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetDefault();
            var response = await httpClient
                .PostProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<AddPostApiResponse> AddPostAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetDefault();
            var response = await httpClient
                .AddUserId(request.UserId)
                .PostAsync<AddPostApiBody, AddPostApiResponse>(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> UpdatePostStatusCodeAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> UpdatePostStatusCodeUnauthorizedAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .PutStatusCodeAsync(route, request.Body, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> UpdatePostProblemDetailsAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> UpdatePostProblemDetailsUnauthorizedAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .PutProblemDetailsAsync(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<UpdatePostApiResponse> UpdatePostAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .PutAsync<UpdatePostApiBody, UpdatePostApiResponse>(route, request.Body, cancellationToken);

            return response!;
        }

        public async Task<HttpStatusCode> DeletePostStatusCodeAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<HttpStatusCode> DeletePostStatusCodeUnauthorizedAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .DeleteStatusCodeAsync(route, cancellationToken);

            return response;
        }

        public async Task<ApplicationProblemDetails> DeletePostProblemDetailsAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .AddUserId(request.UserId)
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task<ApplicationProblemDetails> DeletePostProblemDetailsUnauthorizedAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            var response = await httpClient
                .DeleteProblemDetailsAsync(route, cancellationToken);

            return response!;
        }

        public async Task DeletePostAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetId(request.Id);
            await httpClient
                .AddUserId(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }
    }
}
