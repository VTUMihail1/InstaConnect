using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

internal static class EmailConfirmationTokenHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		internal async Task<HttpResponseMessage> AddResponseMessageAsync(
			AddEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		internal async Task<HttpResponseMessage> VerifyResponseMessageAsync(
			VerifyEmailConfirmationTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = EmailConfirmationTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsync(route, null, cancellationToken);
		}
	}
}
