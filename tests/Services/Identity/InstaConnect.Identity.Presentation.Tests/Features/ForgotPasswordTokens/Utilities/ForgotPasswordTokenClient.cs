using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

internal class ForgotPasswordTokenClient : IForgotPasswordTokenClient
{
	private readonly HttpClient _httpClient;

	public ForgotPasswordTokenClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsync(route, null, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task AddAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await AddResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> VerifyResponseMessageAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsJsonAsync(route, request.Body, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await VerifyResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task VerifyAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await VerifyResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> VerifyStatusCodeAsync(
		VerifyForgotPasswordTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await VerifyResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
