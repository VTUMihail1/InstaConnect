using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceProvider.GetRequiredService<RefreshTokenController>();
		}

		public IRefreshTokenCookieStore GetRefreshTokenCookieStore()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCookieStore>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenController();
		}

		public IRefreshTokenCookieStore GetRefreshTokenCookieStore()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenCookieStore();
		}

		public GetRefreshTokenCookieApiResponse? GetRefreshTokenCookieResponse()
		{
			return serviceScope.GetRefreshTokenCookieStore().Get();
		}

		public async Task<RefreshToken?> GetByIdAsync(
		    GetRefreshTokenCookieApiResponse response,
		    CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new RefreshTokenId(new(response.Id), response.Value),
				cancellationToken);
		}
	}
}
