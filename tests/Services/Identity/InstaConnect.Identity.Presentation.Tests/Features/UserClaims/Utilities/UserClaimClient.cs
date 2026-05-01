using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

internal class UserClaimClient : IUserClaimClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public UserClaimClient(HttpClient httpClient, IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllUnauthorizedResponseMessageAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetAllForbiddenResponseMessageAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllUnauthorizedProblemDetailsAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllForbiddenProblemDetailsAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForbiddenResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllUserClaimsApiResponse> GetAllAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllUserClaimsApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllUnauthorizedStatusCodeAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetAllForbiddenStatusCodeAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllForbiddenResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllUserClaimsApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddUnauthorizedResponseMessageAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddForbiddenResponseMessageAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.Id, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.Id, _baseAccessTokenGenerator)
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddUnauthorizedProblemDetailsAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddForbiddenProblemDetailsAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddForbiddenResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddUserClaimApiResponse> AddAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddUserClaimApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddUnauthorizedStatusCodeAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddForbiddenStatusCodeAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddForbiddenResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteForbiddenResponseMessageAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.Id, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserClaimRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.Id, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteForbiddenProblemDetailsAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteForbiddenResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteForbiddenStatusCodeAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteForbiddenResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteUserClaimApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
