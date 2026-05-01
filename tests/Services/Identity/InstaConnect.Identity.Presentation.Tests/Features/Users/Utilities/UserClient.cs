using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

internal class UserClient : IUserClient
{
	private readonly HttpClient _httpClient;
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public UserClient(HttpClient httpClient, IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_httpClient = httpClient;
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	private async Task<HttpResponseMessage> GetAllResponseMessageAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetAllProblemDetailsAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetAllUsersApiResponse> GetAllAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetAllUsersApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetAllStatusCodeAsync(
		GetAllUsersApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetAllResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetByIdResponseMessageAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetByIdProblemDetailsAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetUserByIdApiResponse> GetByIdAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetUserByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
		GetUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetCurrentByIdUnauthorizedResponseMessageAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetCurrentByIdResponseMessageAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentByIdUnauthorizedProblemDetailsAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentByIdProblemDetailsAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetCurrentUserByIdApiResponse> GetCurrentByIdAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetCurrentUserByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetCurrentByIdUnauthorizedStatusCodeAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetCurrentByIdStatusCodeAsync(
		GetCurrentUserByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetDetailsByIdUnauthorizedResponseMessageAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetDetailsByIdForbiddenResponseMessageAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetDetailsByIdResponseMessageAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdUnauthorizedProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdForbiddenProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdForbiddenResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetDetailsByIdProblemDetailsAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetUserDetailsByIdApiResponse> GetDetailsByIdAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetUserDetailsByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetDetailsByIdUnauthorizedStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetDetailsByIdForbiddenStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdForbiddenResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetDetailsByIdStatusCodeAsync(
		GetUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetDetailsByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.GetAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> GetCurrentDetailsByIdResponseMessageAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.GetAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentDetailsByIdUnauthorizedProblemDetailsAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> GetCurrentDetailsByIdProblemDetailsAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentDetailsByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<GetCurrentUserDetailsByIdApiResponse> GetCurrentDetailsByIdAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentDetailsByIdResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<GetCurrentUserDetailsByIdApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> GetCurrentDetailsByIdUnauthorizedStatusCodeAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> GetCurrentDetailsByIdStatusCodeAsync(
		GetCurrentUserDetailsByIdApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await GetCurrentDetailsByIdResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsync(route, request.Form.GetContent(), cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<AddUserApiResponse> AddAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<AddUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> UpdateCurrentUnauthorizedResponseMessageAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsJsonAsync(route, request.Form.GetContent(), cancellationToken);
	}

	private async Task<HttpResponseMessage> UpdateCurrentResponseMessageAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.Id, _baseAccessTokenGenerator)
			.PutAsync(route, request.Form.GetContent(), cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateCurrentUnauthorizedProblemDetailsAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> UpdateCurrentProblemDetailsAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateCurrentResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<UpdateCurrentUserApiResponse> UpdateCurrentAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateCurrentResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<UpdateCurrentUserApiResponse>(cancellationToken);
	}

	public async Task<HttpStatusCode> UpdateCurrentUnauthorizedStatusCodeAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> UpdateCurrentStatusCodeAsync(
		UpdateCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await UpdateCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteUnauthorizedResponseMessageAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteForbiddenResponseMessageAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.Id, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteResponseMessageAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAdminAuthorization(request.Id, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteUnauthorizedProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteForbiddenProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteForbiddenResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteProblemDetailsAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteUnauthorizedStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteForbiddenStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteForbiddenResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteStatusCodeAsync(
		DeleteUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteCurrentUnauthorizedResponseMessageAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteCurrentResponseMessageAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = UserRouteFactory.GetRoute(request);

		return await _httpClient
			.WithAuthorization(request.CurrentId, _baseAccessTokenGenerator)
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentUnauthorizedProblemDetailsAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentProblemDetailsAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteCurrentAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteCurrentResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> DeleteCurrentUnauthorizedStatusCodeAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentUnauthorizedResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
		DeleteCurrentUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
