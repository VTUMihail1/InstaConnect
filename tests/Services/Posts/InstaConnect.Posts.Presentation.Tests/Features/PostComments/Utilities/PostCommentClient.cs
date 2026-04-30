using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Posts.Presentation.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

internal class PostCommentClient : IPostCommentClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public PostCommentClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentsApiResponse> GetAllAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllPostCommentsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetAllForUserResponseMessageAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllForUserProblemDetailsAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllPostCommentsForUserApiResponse> GetAllForUserAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllPostCommentsForUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForUserStatusCodeAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForUserResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetPostCommentByIdApiResponse> GetByIdAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetPostCommentByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetPostCommentByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddPostCommentApiResponse> AddAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddPostCommentApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddPostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> UpdateUnauthorizedResponseMessageAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> UpdateResponseMessageAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateUnauthorizedProblemDetailsAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateProblemDetailsAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdatePostCommentApiResponse> UpdateAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<UpdatePostCommentApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateUnauthorizedStatusCodeAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateStatusCodeAsync(
		UpdatePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = PostCommentRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.UserId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeletePostCommentApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
