using System.Net;
using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.Chats.Utilities;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> GetAllChatsUnauthorizedResponseMessageAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetAllChatsResponseMessageAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetAllChatsProblemDetailsAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatsResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetAllChatsApiResponse> GetAllChatsAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatsResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetAllChatsApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetAllChatsStatusCodeUnauthorizedAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatsUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetAllChatsStatusCodeAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatsResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetChatByIdUnauthorizedResponseMessageAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetChatByIdResponseMessageAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetChatByIdProblemDetailsAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetChatByIdApiResponse> GetChatByIdAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetChatByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetChatByIdStatusCodeUnauthorizedAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetChatByIdStatusCodeAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> AddChatUnauthorizedResponseMessageAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		private async Task<HttpResponseMessage> AddChatResponseMessageAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddChatProblemDetailsUnauthorizedAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddChatProblemDetailsAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<AddChatApiResponse> AddChatAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<AddChatApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> AddChatStatusCodeUnauthorizedAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> AddChatStatusCodeAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
