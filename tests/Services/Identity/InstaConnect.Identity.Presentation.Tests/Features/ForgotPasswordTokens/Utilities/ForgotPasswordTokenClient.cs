using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> AddForgotPasswordTokenResponseMessageAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddForgotPasswordTokenProblemDetailsAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddForgotPasswordTokenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task AddForgotPasswordTokenAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.AddForgotPasswordTokenResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> AddForgotPasswordTokenStatusCodeAsync(
			AddForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddForgotPasswordTokenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> VerifyForgotPasswordTokenResponseMessageAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = ForgotPasswordTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> VerifyForgotPasswordTokenProblemDetailsAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.VerifyForgotPasswordTokenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task VerifyForgotPasswordTokenAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.VerifyForgotPasswordTokenResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> VerifyForgotPasswordTokenStatusCodeAsync(
			VerifyForgotPasswordTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.VerifyForgotPasswordTokenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
