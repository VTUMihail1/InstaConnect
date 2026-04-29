using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> GetAllFollowsResponseMessageAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetAllFollowsProblemDetailsAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetAllFollowsApiResponse> GetAllFollowsAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetAllFollowsApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetAllFollowsStatusCodeAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetAllFollowsForFollowingResponseMessageAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetAllFollowsForFollowingProblemDetailsAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsForFollowingResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetAllFollowsForFollowingApiResponse> GetAllFollowsForFollowingAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsForFollowingResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetAllFollowsForFollowingApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetAllFollowsForFollowingStatusCodeAsync(
			GetAllFollowsForFollowingApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllFollowsForFollowingResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetFollowByIdResponseMessageAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetFollowByIdProblemDetailsAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetFollowByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetFollowByIdApiResponse> GetFollowByIdAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetFollowByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetFollowByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetFollowByIdStatusCodeAsync(
			GetFollowByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetFollowByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> AddFollowUnauthorizedResponseMessageAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		private async Task<HttpResponseMessage> AddFollowResponseMessageAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.FollowerId)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddFollowProblemDetailsUnauthorizedAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddFollowUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddFollowProblemDetailsAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddFollowResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<AddFollowApiResponse> AddFollowAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddFollowResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<AddFollowApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> AddFollowStatusCodeUnauthorizedAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddFollowUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> AddFollowStatusCodeAsync(
			AddFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddFollowResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> DeleteFollowUnauthorizedResponseMessageAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> DeleteFollowResponseMessageAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = FollowRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.FollowerId)
				.DeleteAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteFollowProblemDetailsUnauthorizedAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteFollowUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteFollowProblemDetailsAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteFollowResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task DeleteFollowAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.DeleteFollowResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> DeleteFollowStatusCodeUnauthorizedAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteFollowUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> DeleteFollowStatusCodeAsync(
			DeleteFollowApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteFollowResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
