using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimCommandService GetUserClaimCommandService()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandService>();
		}

		public IUserClaimQueryService GetUserClaimQueryService()
		{
			return serviceProvider.GetRequiredService<IUserClaimQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimCommandService GetUserClaimCommandService()
		{
			return serviceScope.ServiceProvider.GetUserClaimCommandService();
		}

		public IUserClaimQueryService GetUserClaimQueryService()
		{
			return serviceScope.ServiceProvider.GetUserClaimQueryService();
		}
	}
}
