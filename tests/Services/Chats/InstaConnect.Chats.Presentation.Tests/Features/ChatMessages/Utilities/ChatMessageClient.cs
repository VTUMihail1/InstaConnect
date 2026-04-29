using System.Net;
using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> GetAllChatMessagesUnauthorizedResponseMessageAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetAllChatMessagesResponseMessageAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetAllChatMessagesProblemDetailsAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatMessagesResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetAllChatMessagesApiResponse> GetAllChatMessagesAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatMessagesResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetAllChatMessagesApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetAllChatMessagesStatusCodeUnauthorizedAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatMessagesUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetAllChatMessagesStatusCodeAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllChatMessagesResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetChatMessageByIdUnauthorizedResponseMessageAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetChatMessageByIdResponseMessageAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentUserId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetChatMessageByIdProblemDetailsAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatMessageByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetChatMessageByIdApiResponse> GetChatMessageByIdAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatMessageByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetChatMessageByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetChatMessageByIdStatusCodeUnauthorizedAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatMessageByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetChatMessageByIdStatusCodeAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetChatMessageByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> AddChatMessageUnauthorizedResponseMessageAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		private async Task<HttpResponseMessage> AddChatMessageResponseMessageAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId)
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddChatMessageProblemDetailsUnauthorizedAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddChatMessageProblemDetailsAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatMessageResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<AddChatMessageApiResponse> AddChatMessageAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatMessageResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<AddChatMessageApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> AddChatMessageStatusCodeUnauthorizedAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> AddChatMessageStatusCodeAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddChatMessageResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> UpdateChatMessageUnauthorizedResponseMessageAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		private async Task<HttpResponseMessage> UpdateChatMessageResponseMessageAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId)
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> UpdateChatMessageProblemDetailsUnauthorizedAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> UpdateChatMessageProblemDetailsAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateChatMessageResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<UpdateChatMessageApiResponse> UpdateChatMessageAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateChatMessageResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<UpdateChatMessageApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> UpdateChatMessageStatusCodeUnauthorizedAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> UpdateChatMessageStatusCodeAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateChatMessageResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> DeleteChatMessageUnauthorizedResponseMessageAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> DeleteChatMessageResponseMessageAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ChatMessageRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.ParticipantOneId)
				.DeleteAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteChatMessageProblemDetailsUnauthorizedAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteChatMessageProblemDetailsAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteChatMessageResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task DeleteChatMessageAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.DeleteChatMessageResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> DeleteChatMessageStatusCodeUnauthorizedAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteChatMessageUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> DeleteChatMessageStatusCodeAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteChatMessageResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
