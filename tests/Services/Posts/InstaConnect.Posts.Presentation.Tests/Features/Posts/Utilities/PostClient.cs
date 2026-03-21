using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllPostsResponseMessageAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostsProblemDetailsAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostsApiResponse> GetAllPostsAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostsApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostsStatusCodeAsync(
            GetAllPostsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetAllPostsForUserResponseMessageAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostsForUserProblemDetailsAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostsForUserApiResponse> GetAllPostsForUserAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostsForUserApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostsForUserStatusCodeAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostsForUserResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetPostByIdResponseMessageAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetPostByIdProblemDetailsAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetPostByIdApiResponse> GetPostByIdAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetPostByIdApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetPostByIdStatusCodeAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostByIdResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddPostUnauthorizedResponseMessageAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddPostResponseMessageAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostProblemDetailsUnauthorizedAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostProblemDetailsAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<AddPostApiResponse> AddPostAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<AddPostApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> AddPostStatusCodeUnauthorizedAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> AddPostStatusCodeAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> UpdatePostUnauthorizedResponseMessageAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .PutAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> UpdatePostResponseMessageAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PutAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> UpdatePostProblemDetailsUnauthorizedAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> UpdatePostProblemDetailsAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<UpdatePostApiResponse> UpdatePostAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<UpdatePostApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> UpdatePostStatusCodeUnauthorizedAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> UpdatePostStatusCodeAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeletePostUnauthorizedResponseMessageAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeletePostResponseMessageAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostProblemDetailsUnauthorizedAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostProblemDetailsAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeletePostAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeletePostResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeletePostStatusCodeUnauthorizedAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeletePostStatusCodeAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
