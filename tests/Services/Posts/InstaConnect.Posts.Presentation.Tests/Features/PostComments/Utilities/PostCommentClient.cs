using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentClient
{
    extension(HttpClient httpClient)
    {
        private async Task<HttpResponseMessage> GetAllPostCommentsResponseMessageAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentsProblemDetailsAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostCommentsApiResponse> GetAllPostCommentsAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostCommentsApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostCommentsStatusCodeAsync(
            GetAllPostCommentsApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetAllPostCommentsForUserResponseMessageAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetAllPostCommentsForUserProblemDetailsAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetAllPostCommentsForUserApiResponse> GetAllPostCommentsForUserAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsForUserResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetAllPostCommentsForUserApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetAllPostCommentsForUserStatusCodeAsync(
            GetAllPostCommentsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAllPostCommentsForUserResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> GetPostCommentByIdResponseMessageAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.CurrentUserId)
                .GetAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> GetPostCommentByIdProblemDetailsAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<GetPostCommentByIdApiResponse> GetPostCommentByIdAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentByIdResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<GetPostCommentByIdApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> GetPostCommentByIdStatusCodeAsync(
            GetPostCommentByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetPostCommentByIdResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> AddPostCommentUnauthorizedResponseMessageAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> AddPostCommentResponseMessageAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PostAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsUnauthorizedAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> AddPostCommentProblemDetailsAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<AddPostCommentApiResponse> AddPostCommentAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<AddPostCommentApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> AddPostCommentStatusCodeUnauthorizedAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> AddPostCommentStatusCodeAsync(
            AddPostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.AddPostCommentResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> UpdatePostCommentUnauthorizedResponseMessageAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .PutAsJsonAsync(route, request.Body, cancellationToken);
        }

        private async Task<HttpResponseMessage> UpdatePostCommentResponseMessageAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .PutAsJsonAsync(route, request.Body, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsUnauthorizedAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> UpdatePostCommentProblemDetailsAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostCommentResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<UpdatePostCommentApiResponse> UpdatePostCommentAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostCommentResponseMessageAsync(request, cancellationToken);

            return await response.GetFromJsonAsync<UpdatePostCommentApiResponse>(cancellationToken);
        }

        public async Task<HttpStatusCode> UpdatePostCommentStatusCodeUnauthorizedAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> UpdatePostCommentStatusCodeAsync(
            UpdatePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.UpdatePostCommentResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        private async Task<HttpResponseMessage> DeletePostCommentUnauthorizedResponseMessageAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .DeleteAsync(route, cancellationToken);
        }

        private async Task<HttpResponseMessage> DeletePostCommentResponseMessageAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var route = PostCommentTestRoutes.GetRoute(request);

            return await httpClient
                .WithAuthorization(request.UserId)
                .DeleteAsync(route, cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsUnauthorizedAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task<ApplicationProblemDetails> DeletePostCommentProblemDetailsAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentResponseMessageAsync(request, cancellationToken);

            return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
        }

        public async Task DeletePostCommentAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            await httpClient.DeletePostCommentResponseMessageAsync(request, cancellationToken);
        }

        public async Task<HttpStatusCode> DeletePostCommentStatusCodeUnauthorizedAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentUnauthorizedResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }

        public async Task<HttpStatusCode> DeletePostCommentStatusCodeAsync(
            DeletePostCommentApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeletePostCommentResponseMessageAsync(request, cancellationToken);

            return response.GetStatusCode();
        }
    }
}
