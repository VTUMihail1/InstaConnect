using System.Net;
using System.Net.Http.Json;

using InstaConnect.Chats.Presentation.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

internal class ChatClient : IChatClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public ChatClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
			GetAllChatsApiRequest request,
			CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllChatsApiResponse> GetAllAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllChatsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllUnauthorizedStatusCodeAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdUnauthorizedResponseMessageAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetChatByIdApiResponse> GetByIdAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetChatByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdUnauthorizedStatusCodeAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetChatByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ChatRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.ParticipantOneId, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddChatApiResponse> AddAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddChatApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddChatApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
