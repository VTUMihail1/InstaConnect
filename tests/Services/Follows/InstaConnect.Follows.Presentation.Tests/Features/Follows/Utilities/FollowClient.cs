using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

internal class FollowClient : IFollowClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public FollowClient(
		HttpClient httpClient,
		IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
			GetAllFollowsApiRequest request,
			CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllFollowsApiResponse> GetAllAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllFollowsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllFollowsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetAllForFollowingResponseMessageAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllForFollowingProblemDetailsAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForFollowingResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllFollowsForFollowingApiResponse> GetAllForFollowingAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForFollowingResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllFollowsForFollowingApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllForFollowingStatusCodeAsync(
		GetAllFollowsForFollowingApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForFollowingResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentUserId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetFollowByIdApiResponse> GetByIdAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetFollowByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetFollowByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.FollowerId, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddFollowApiResponse> AddAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddFollowApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = FollowRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.FollowerId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteFollowApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
