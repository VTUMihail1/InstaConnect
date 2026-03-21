using InstaConnect.Common.Tests.Events;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Utilities;

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
    }
}
