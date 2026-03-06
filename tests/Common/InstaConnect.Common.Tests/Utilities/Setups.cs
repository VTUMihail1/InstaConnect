using InstaConnect.Common.Tests.Events;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Utilities;

public static class Setups
{
    extension(IServiceScope serviceScope)
    {
        public IEventHarness GetEventHarness()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IEventHarness>();
        }

        public IApplicationSender GetSender()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IApplicationSender>();
        }
    }
}
