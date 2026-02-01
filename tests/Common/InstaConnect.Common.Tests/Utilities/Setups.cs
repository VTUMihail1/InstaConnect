using InstaConnect.Common.Tests.Events;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Utilities;

public static class Setups
{
    public static IEventHarness GetEventHarness(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IEventHarness>();
    }

    public static IApplicationSender GetSender(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IApplicationSender>();
    }
}
