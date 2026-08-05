using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenControllerSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceProvider.GetRequiredService<RefreshTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public RefreshTokenController GetRefreshTokenController()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenController();
		}
	}
}
