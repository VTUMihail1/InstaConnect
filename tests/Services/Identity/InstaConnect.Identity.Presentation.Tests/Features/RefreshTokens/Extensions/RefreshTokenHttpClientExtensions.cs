using System.Net.Http.Json;

using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

public static class RefreshTokenHttpClientExtensions
{
	extension(HttpClient httpClient)
	{
		public async Task<HttpResponseMessage> IssueResponseMessageAsync(
			IssueRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsJsonAsync(route, request.Body, cancellationToken);
		}

		public async Task<HttpResponseMessage> RotateWithoutCookiesResponseMessageAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, null, cancellationToken);
		}

		public async Task<HttpResponseMessage> RotateResponseMessageAsync(
			RotateRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.WithRefreshTokenCookies(request.Id, request.Value)
				.PostAsync(route, null, cancellationToken);
		}

		public async Task<HttpResponseMessage> DeleteCurrentWithoutCookiesResponseMessageAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		public async Task<HttpResponseMessage> DeleteCurrentResponseMessageAsync(
			DeleteCurrentRefreshTokenApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = RefreshTokenRouteFactory.GetRoute(request);

			return await httpClient
				.WithRefreshTokenCookies(request.Id, request.Value)
				.DeleteAsync(route, cancellationToken);
		}

		public HttpClient WithRefreshTokenCookies(
			string id,
			string value)
		{
			return httpClient
				.WithCookies(new(RefreshTokenCookieKeys.Id, id),
							 new(RefreshTokenCookieKeys.Value, value));
		}
	}

	extension(HttpResponseMessage httpResponseMessage)
	{
		public async Task<RefreshTokenCookieApiResponse?> GetRefreshTokenCookieApiResponse()
		{
			var id = httpResponseMessage.GetCookie(RefreshTokenCookieKeys.Id);
			var value = httpResponseMessage.GetCookie(RefreshTokenCookieKeys.Value);

			if (id.IsEmpty() && value.IsEmpty())
			{
				return null;
			}

			return new(id, value);
		}
	}
}
