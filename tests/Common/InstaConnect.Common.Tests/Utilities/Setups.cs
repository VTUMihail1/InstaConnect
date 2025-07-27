using System.Threading;

using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities.Events;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Utilities;

public static class Setups
{
    public static IEventHarness GetEventHarness(this IServiceScope serviceScope)
    {
        var eventHarness = serviceScope.ServiceProvider.GetRequiredService<IEventHarness>();

        return eventHarness;
    }

    public static IApplicationSender GetApplicationSender(this IServiceScope serviceScope)
    {
        var applicationSender = serviceScope.ServiceProvider.GetRequiredService<IApplicationSender>();

        return applicationSender;
    }

    public static IUnitOfWork GetUnitOfWork(this IServiceScope serviceScope)
    {
        var unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        return unitOfWork;
    }
}
