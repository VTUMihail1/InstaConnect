using System.Net;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

internal class EmailConfirmationTokenClient : IEmailConfirmationTokenClient
{
	private readonly HttpClient _httpClient;

	public EmailConfirmationTokenClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	private async Task<HttpResponseMessage> AddResponseMessageAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PostAsync(route, null, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> AddProblemDetailsAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task AddAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await AddResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> AddStatusCodeAsync(
		AddEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await AddResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}

	private async Task<HttpResponseMessage> VerifyResponseMessageAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

		return await _httpClient
			.PutAsync(route, null, cancellationToken);
	}

	public async Task<ApplicationProblemDetails> VerifyProblemDetailsAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await VerifyResponseMessageAsync(request, cancellationToken);

		return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
	}

	public async Task VerifyAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		await VerifyResponseMessageAsync(request, cancellationToken);
	}

	public async Task<HttpStatusCode> VerifyStatusCodeAsync(
		VerifyEmailConfirmationTokenApiRequest request,
		CancellationToken cancellationToken)
	{
		var response = await VerifyResponseMessageAsync(request, cancellationToken);

		return response.GetStatusCode();
	}
}
