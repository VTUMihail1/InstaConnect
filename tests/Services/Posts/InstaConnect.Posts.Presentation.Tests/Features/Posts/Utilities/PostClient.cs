using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

internal class PostClient : IPostClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public PostClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostsApiResponse> GetAllAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllPostsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
		GetAllPostsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(
		GetAllPostsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostsForUserApiResponse> GetAllForUserAsync(
		GetAllPostsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostsForUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForUserStatusCodeAsync(
		GetAllPostsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetPostByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetPostByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetPostByIdApiResponse> GetByIdAsync(
		GetPostByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetPostByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetPostByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddPostApiResponse> AddAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddPostApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddPostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> UpdateResponseMessageAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateUnauthorizedProblemDetailsAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateProblemDetailsAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdatePostApiResponse> UpdateAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<UpdatePostApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateUnauthorizedStatusCodeAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateStatusCodeAsync(
		UpdatePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeletePostApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
