using System.Net;
using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

internal class ChatMessageClient : IChatMessageClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public ChatMessageClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
			GetAllChatMessagesApiRequest request,
			CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllChatMessagesApiResponse> GetAllAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllChatMessagesApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllUnauthorizedStatusCodeAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdUnauthorizedResponseMessageAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetChatMessageByIdApiResponse> GetByIdAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetChatMessageByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdUnauthorizedStatusCodeAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetChatMessageByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.ParticipantOneId, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddChatMessageApiResponse> AddAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddChatMessageApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> UpdateResponseMessageAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.ParticipantOneId, _baseAccessTokenGenerator)
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateUnauthorizedProblemDetailsAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateProblemDetailsAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdateChatMessageApiResponse> UpdateAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<UpdateChatMessageApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateUnauthorizedStatusCodeAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateStatusCodeAsync(
		UpdateChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatMessageRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.ParticipantOneId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteChatMessageApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
