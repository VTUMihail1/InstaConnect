using System.Net;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> AddEmailConfirmationTokenResponseMessageAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddEmailConfirmationTokenProblemDetailsAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task AddEmailConfirmationTokenAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.AddEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> AddEmailConfirmationTokenStatusCodeAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> VerifyEmailConfirmationTokenResponseMessageAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsync(route, null, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> VerifyEmailConfirmationTokenProblemDetailsAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.VerifyEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task VerifyEmailConfirmationTokenAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.VerifyEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> VerifyEmailConfirmationTokenStatusCodeAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.VerifyEmailConfirmationTokenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
