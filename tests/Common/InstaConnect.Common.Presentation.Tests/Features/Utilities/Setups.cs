using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Tests.Features.Events;

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
