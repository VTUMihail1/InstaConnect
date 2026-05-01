using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;

using Microsoft.Net.Http.Headers;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

internal class RefreshTokenClient : IRefreshTokenClient
{
	private readonly HttpClient _httpClient;

	public RefreshTokenClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	private async Task<HttpResponseMessage> IssueResponseMessageAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = RefreshTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> IssueProblemDetailsAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await IssueResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<IssueRefreshTokenApiResponse> IssueAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await IssueResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<IssueRefreshTokenApiResponse>(cancellationToken);
	}

	public async Task<ICollection<SetCookieHeaderValue>> IssueResponseCookiesAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await IssueResponseMessageAsync(request, cancellationToken);

		return response.GetCookies();
	}

	public async Task<HttpStatusCode> IssueStatusCodeAsync(
		IssueRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await IssueResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> RotateWithoutCookiesResponseMessageAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = RefreshTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsync(route, null, cancellationToken);
	}

	private async Task<HttpResponseMessage> RotateResponseMessageAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = RefreshTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.WithCookies(new(RefreshTokenCookieKeys.Id, request.Id),
						 new(RefreshTokenCookieKeys.Value, request.Value))
			.PostAsync(route, null, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> RotateWithoutCookiesProblemDetailsAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> RotateProblemDetailsAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<RotateRefreshTokenApiResponse> RotateAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateResponseMessageAsync(request, cancellationToken);

		return await response.GetFromJsonAsync<RotateRefreshTokenApiResponse>(cancellationToken);
	}

	public async Task<ICollection<SetCookieHeaderValue>> RotateResponseCookiesAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateResponseMessageAsync(request, cancellationToken);

		return response.GetCookies();
	}

	public async Task<HttpStatusCode> RotateWithoutCookiesStatusCodeAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> RotateStatusCodeAsync(
		RotateRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await RotateResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> DeleteCurrentWithoutCookiesResponseMessageAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = RefreshTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.DeleteAsync(route, cancellationToken);
	}

	private async Task<HttpResponseMessage> DeleteCurrentResponseMessageAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = RefreshTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.WithCookies(new(RefreshTokenCookieKeys.Id, request.Id),
						 new(RefreshTokenCookieKeys.Value, request.Value))
			.DeleteAsync(route, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentWithoutCookiesProblemDetailsAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task<ApplicationProblemDetails> DeleteCurrentProblemDetailsAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task DeleteCurrentAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await DeleteCurrentResponseMessageAsync(request, cancellationToken);
	}

	public async Task<ICollection<SetCookieHeaderValue>> DeleteCurrentResponseCookiesAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetCookies();
	}

	public async Task<HttpStatusCode> DeleteCurrentWithoutCookiesStatusCodeAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentWithoutCookiesResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
		DeleteCurrentRefreshTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await DeleteCurrentResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
