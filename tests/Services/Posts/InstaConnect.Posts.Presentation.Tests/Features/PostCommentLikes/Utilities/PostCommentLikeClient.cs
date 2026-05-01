using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

internal class PostCommentLikeClient : IPostCommentLikeClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public PostCommentLikeClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentLikesApiResponse> GetAllAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentLikesApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllPostCommentLikesApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
		GetAllPostCommentLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(
		GetAllPostCommentLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentLikesForUserApiResponse> GetAllForUserAsync(
		GetAllPostCommentLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentLikesForUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForUserStatusCodeAsync(
		GetAllPostCommentLikesForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetPostCommentLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetPostCommentLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetPostCommentLikeByIdApiResponse> GetByIdAsync(
		GetPostCommentLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetPostCommentLikeByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetPostCommentLikeByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsync(route, null, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.PostAsync(route, null, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddPostCommentLikeApiResponse> AddAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddPostCommentLikeApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddPostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentLikeRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeletePostCommentLikeApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
