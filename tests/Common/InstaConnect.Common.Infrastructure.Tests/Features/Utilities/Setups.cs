using InstaConnect.Common.Events.Features.Common.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

public static class Setups
{
	extension(IServiceProvider serviceProvider)
	{
		public IEventPublisher GetEventPublisher()
		{
			return serviceProvider.GetRequiredService<IEventPublisher>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IEventPublisher GetEventPublisher()
		{
			return serviceScope.ServiceProvider.GetEventPublisher();
		}
	}
}
