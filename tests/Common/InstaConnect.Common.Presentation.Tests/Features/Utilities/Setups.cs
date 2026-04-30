using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class Setups
{
	extension(IServiceProvider serviceProvider)
	{
		public IBaseAccessTokenGenerator GetBaseAccessTokenGenerator()
		{
			return serviceProvider.GetRequiredService<IBaseAccessTokenGenerator>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IBaseAccessTokenGenerator GetBaseAccessTokenGenerator()
		{
			return serviceScope.ServiceProvider.GetBaseAccessTokenGenerator();
		}
	}
}
