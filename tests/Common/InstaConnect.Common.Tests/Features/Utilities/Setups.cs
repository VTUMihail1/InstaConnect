using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Tests.Features.Events;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class Setups
{
    extension(IServiceProvider serviceProvider)
    {
        public IEventHarness GetEventHarness()
        {
            return serviceProvider.GetRequiredService<IEventHarness>();
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
    }

    extension(IServiceScope serviceScope)
    {
        public IEventHarness GetEventHarness()
        {
            return serviceScope.ServiceProvider.GetEventHarness();
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
    }
}
