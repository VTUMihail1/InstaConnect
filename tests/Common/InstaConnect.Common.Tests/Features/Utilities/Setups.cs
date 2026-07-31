using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Common.Tests.Features.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class Setups
{
	extension(IServiceProvider serviceProvider)
	{
		public IEventClient GetEventClient()
		{
			return serviceProvider.GetRequiredService<IEventClient>();
		}

		public IImageHandler GetImageHandler()
		{
			return serviceProvider.GetRequiredService<IImageHandler>();
		}

		public IApplicationSender GetSender()
		{
			return serviceProvider.GetRequiredService<IApplicationSender>();
		}

		public ICacheHandler GetCacheHandler()
		{
			return serviceProvider.GetRequiredService<ICacheHandler>();
		}

		public IBaseAccessTokenGenerator GetBaseAccessTokenGenerator()
		{
			return serviceProvider.GetRequiredService<IBaseAccessTokenGenerator>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IEventClient GetEventClient()
		{
			return serviceScope.ServiceProvider.GetEventClient();
		}

		public IImageHandler GetImageHandler()
		{
			return serviceScope.ServiceProvider.GetImageHandler();
		}

		public IApplicationSender GetSender()
		{
			return serviceScope.ServiceProvider.GetSender();
		}

		public ICacheHandler GetCacheHandler()
		{
			return serviceScope.ServiceProvider.GetCacheHandler();
		}

		public IBaseAccessTokenGenerator GetBaseAccessTokenGenerator()
		{
			return serviceScope.ServiceProvider.GetBaseAccessTokenGenerator();
		}
	}
}
